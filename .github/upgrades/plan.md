# .NET 10 Upgrade Plan

Table of contents

- [1. Executive Summary](#executive-summary)
- [2. Migration Strategy](#migration-strategy)
- [3. Detailed Dependency Analysis](#detailed-dependency-analysis)
- [4. Project-by-Project Plans](#project-by-project-plans)
- [5. Package Update Reference](#package-update-reference)
- [6. Breaking Changes Catalog](#breaking-changes-catalog)
- [7. Testing & Validation Strategy](#testing--validation-strategy)
- [8. Risk Management](#risk-management)
- [9. Complexity & Effort Assessment](#complexity--effort-assessment)
- [10. Source Control Strategy](#source-control-strategy)
- [11. Success Criteria](#success-criteria)


## 1. Executive Summary
This plan upgrades the repository from .NET 8 to .NET 10 (Long Term Support) using an All-At-Once strategy: all projects and MSBuild imports are updated in a single atomic operation.

Scope
- Solution: `Ahnenforscherin.slnx`
- Projects: 1 (all projects upgraded simultaneously)
- Primary project: `Ahnenforscherin\Ahnenforscherin.csproj` (WinForms, SDK-style)

Key metrics (from assessment)
- Total projects: 1 (all require upgrade)
- Total LOC: 2,713
- Files: ~80
- Files with incidents: 12
- Total NuGet packages: 3 (1 requires upgrade)
- Total API issues flagged: 51 (23 source-incompatible, 26 behavioral)
- Estimated LOC to modify: 49+

Selected Strategy
- `All-At-Once Strategy` — Atomic, single coordinated upgrade of all projects to `.NET 10.0`.

Rationale
- Small solution (1 project) with SDK-style project and limited dependency complexity.
- Assessment shows package updates are available and compatible with .NET 10.
- Test surface and code changes are modest (estimated ~49 LOC), so an atomic upgrade minimizes overhead and keeps changes consolidated.


## 2. Migration Strategy
Strategy Overview

- Approach: All projects upgraded simultaneously in a single coordinated operation (atomic upgrade).
- Rationale: Single, small SDK-style WinForms project with few package updates and limited API incidents.

Phases (conceptual, not separate per-project tasks)

- Phase 0 — Preparation (prerequisites)
  - Verify .NET 10 SDK availability and `global.json` (if present).
  - Ensure repository is on the selected upgrade branch and pending changes are handled (commit, stash, or undo per repo state).

- Phase 1 — Atomic Upgrade (single operation)
  - Update `TargetFramework` to `net10.0-windows10.0.22000.0` in all projects and any imported MSBuild props/targets (`Directory.Build.props`, etc.).
  - Update all PackageReference versions as specified in §5 Package Update Reference.
  - Restore dependencies and build the entire solution to discover compilation errors.
  - Fix compilation errors caused by framework/package updates (code changes described in §4 Project-by-Project Plans and §6 Breaking Changes Catalog).
  - Ensure solution builds with 0 errors.

- Phase 2 — Test Validation
  - Execute unit/integration tests (if any) and validate runtime behavioral changes described in §6.
  - Address failing tests and regressions.

Batching and Tasks

- Single atomic upgrade task will contain: project file updates, package updates, restore, build, fix compilation errors, and verification (see Task generation guidance in plan header). Prerequisite steps (SDK/global.json/branch handling) are a separate preparatory task.


## 3. Detailed Dependency Analysis
Summary

- Projects: 1 — `Ahnenforscherin\Ahnenforscherin.csproj` (no project-to-project dependencies)
- Dependency depth: 0 (leaf and root are the same project)
- No circular dependencies reported

Implications for All-At-Once

- With a single project and no inter-project dependencies, the atomic upgrade scope is the project itself plus any shared MSBuild imports (if present). There is no multi-phase dependency ordering required.


## 4. Project-by-Project Plans

### Project: `Ahnenforscherin\Ahnenforscherin.csproj`

Current State
- TargetFramework: `net8.0-windows10.0.19041.0`
- Proposed TargetFramework: `net10.0-windows10.0.22000.0`
- Project kind: WinForms (SDK-style)
- Dependencies: 0 (no project references)
- Packages: 3 total; 1 recommended update (EF Core)
- LOC: 2,713; estimated LOC to change: 49+

Target State
- Project targets `.NET 10.0` with `TargetFramework` set to `net10.0-windows10.0.22000.0`.
- All PackageReference entries updated to versions known to be compatible with .NET 10 (see §5).

Migration Steps (atomic operation)
1. Preparation
   - Ensure `.NET 10 SDK` is installed on CI and developer machines, and `global.json` (if present) references an SDK that supports `.NET 10` or is updated accordingly. (See Phase 0 prerequisites)
   - Ensure working tree is on the upgrade branch with pending changes handled.

2. Project file updates
   - Update the `TargetFramework` element in `Ahnenforscherin.csproj` to `net10.0-windows10.0.22000.0`.
   - Inspect `Directory.Build.props/targets`, `Directory.Packages.props` (repo root and parent folders) and update any framework- or package-related properties in a single coordinated change.

3. Package updates
   - Update `Microsoft.EntityFrameworkCore` from `9.0.9` ? `10.0.2`.
   - Leave `Microsoft.Windows.SDK.BuildTools` and `Microsoft.WindowsAppSDK` at current versions (assessment reports compatible), unless CI/compile reports indicate otherwise.

4. Build and fix compilation errors
   - Restore packages and build the solution. Expect to address the source-incompatible API usages listed in §6.
   - Replace or adapt usages for `Windows.UI.Color` occurrences and review `System.Uri` behavioral changes.

5. Validation
   - Confirm solution builds with 0 errors.
   - Run available automated tests (unit/integration) and confirm pass status.

Validation Checklist
- [ ] `TargetFramework` set to `net10.0-windows10.0.22000.0` in `Ahnenforscherin.csproj`.
- [ ] `Microsoft.EntityFrameworkCore` updated to `10.0.2`.
- [ ] Solution restores and builds with 0 errors.
- [ ] No remaining security vulnerabilities reported for packages.

Notes & Assumptions
- No third-party packages require replacement other than versions listed in §5. If additional incompatible packages are found during build, treat them as blockers and escalate.


## 5. Package Update Reference

Common package updates (affecting multiple projects)

| Package | Current | Target | Projects Affected | Reason |
|---|---:|---:|---|---|
| `Microsoft.EntityFrameworkCore` | 9.0.9 | 10.0.2 | `Ahnenforscherin.csproj` (1) | Recommended upgrade for .NET 10 compatibility |

Category-specific / project-specific

- `Microsoft.Windows.SDK.BuildTools` — current: `10.0.26100.7463` — assessment: compatible; no change required.
- `Microsoft.WindowsAppSDK` — current: `1.8.260101001` — assessment: compatible; no change required.

Security

- Assessment did not list package vulnerabilities. If vulnerability findings appear in analysis tools (Dependabot, NuGet audit) during the upgrade, prioritize those updates and include in the atomic upgrade.


## 6. Breaking Changes Catalog

Overview

- The assessment flagged primarily source-incompatible and behavioral changes. No binary-incompatible APIs were detected.

Top areas to review after upgrading and expected remediation guidance

1. `Windows.UI.Color` usages (Source Incompatible)
   - Instances: 19 occurrences reported in assessment.
   - Impact: Code referencing `Windows.UI.Color` (UWP/WinRT type) may need adaptation when running under newer Windows App SDK or when projecting types into WinForms. Review each usage and map to supported types (for WinForms, consider `System.Drawing.Color` or `Windows.UI` projection adapters). Steps:
     - Identify files using `Windows.UI.Color` and `Windows.UI.Color.FromArgb`.
     - Replace with `System.Drawing.Color` where appropriate, or wrap conversion helper methods that map ARGB values.
     - Mark conversions with unit tests or focused runtime checks.

2. `System.Uri` behavioral changes (Behavioral Change)
   - Instances: 15 occurrences reported; constructors: 11 occurrences.
   - Impact: URI parsing/normalization and equality semantics may differ; tests relying on exact string comparisons or parsing side-effects should be validated.
   - Steps:
     - Run codepaths that construct `Uri` from user or config input and validate expectations.
     - If parsing behavior changes break logic, add normalization and explicit parsing rules.

3. Miscellaneous source-incompatible APIs (23 total)
   - Review compiler errors produced after the first build pass and apply targeted refactors. Common patterns: namespace changes, moved types, obsolete API replacements.

?? Unknowns: Additional breaking changes may surface during the build after packages are updated. Treat the first build as the canonical discovery step and address errors as they appear.


## 7. Testing & Validation Strategy

Levels of validation

- Local developer validation: dotnet restore ? dotnet build ? run local sample scenarios. Confirm UI startup for WinForms app.
- Automated tests: run unit and integration tests discovered by test discovery tooling. (Assessment lists no dedicated test projects; if present, include here.)
- Post-upgrade smoke tests: validate common user flows (open app, load data, basic CRUD operations).

Checklist
- [ ] All builds succeed with 0 errors.
- [ ] All automated tests pass.
- [ ] Key runtime scenarios exercised and validated (UI startup, data load).

Notes on behavioral risks

- `System.Uri` behavioral changes require functional test coverage around parsing and equality.
- `Windows.UI.Color` replacements require visual verification of colors in UI flows; where possible, add unit checks for conversion helpers.


## 8. Risk Management

Top risks

- R1: Package update introduces unexpected API changes that require larger refactors.
  - Level: Medium
  - Mitigation: Apply all package updates in the atomic pass; run full build to enumerate errors; allocate time for code fixes. Keep a fallback: if a package upgrade blocks progress, pin to previous major and open an investigation PR.

- R2: Behavioral changes in `System.Uri` break logic.
  - Level: Medium
  - Mitigation: Add normalization/parsing layers and extend unit tests to capture expected behavior.

- R3: UI differences from color type replacements.
  - Level: Low
  - Mitigation: Implement conversion helpers and add visual verification during smoke tests.

Contingency / rollback

- Use feature branch for the atomic upgrade. If the upgrade introduces blocking regressions that cannot be resolved within the upgrade task window, revert the branch or create a hotfix branch based on the pre-upgrade baseline.


## 9. Complexity & Effort Assessment

Overall classification: Low complexity

Rationale
- Single project, moderate LOC, limited package updates, well-scoped API issues (~49 LOC estimated to change).

Per-project complexity
- `Ahnenforscherin.csproj` — Low (SDK-style WinForms, few package updates, limited API changes).


## 10. Source Control Strategy

Branching

- Create a dedicated upgrade branch (e.g., `upgrade/dotnet-10`) from the selected source branch.
- Handle pending changes before branch creation (commit, stash, or undo) per repository state.

Commits

- Prefer a single atomic commit for the framework & package updates and the compilation fixes that result from them, to keep the upgrade self-contained. If changes are large, group logically but keep the intent focused: "Upgrade to .NET 10.0 — project files & package updates; fix compilation issues".

Pull Request & Review

- Open a PR from `upgrade/dotnet-10` to the mainline branch with a description of changes, referenced assessment, and testing checklist.

CI

- Ensure CI uses .NET 10 SDK for build and test runs for the PR.


## 11. Success Criteria

The migration is complete when the following are met:

1. All projects target `net10.0` with appropriate RID (e.g., `net10.0-windows10.0.22000.0`) as specified in the assessment.
2. All package updates from §5 are applied.
3. Solution builds with 0 errors.
4. All automated tests pass.
5. No outstanding security vulnerabilities remain in NuGet dependencies.
6. Visual/UI smoke tests for WinForms app complete without regressions related to color rendering or URI handling.

---

Notes and follow-ups

- If additional incompatible packages are discovered during the build, add them to §5 and re-run the atomic upgrade pass.
- Document any nontrivial code changes made while fixing compilation errors in the PR description and link to corresponding sections in this plan.

<!-- End of plan content -->


<!-- End of skeleton -->