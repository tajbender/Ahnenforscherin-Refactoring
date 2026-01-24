# Ahnenforscherin .NET 10 Upgrade Tasks

## Overview

This document tracks the atomic upgrade of the `Ahnenforscherin` solution from .NET 8 to .NET 10. The upgrade will be performed as a single coordinated change to project files and package references, followed by test validation.

**Progress**: 1/3 tasks complete (33%) ![0%](https://progress-bar.xyz/33)

---

## Tasks

### [✓] TASK-001: Verify prerequisites *(Completed: 2026-01-24 16:08)*
**References**: Plan §Phase 0, Plan §2 Migration Strategy

- [✓] (1) Verify `.NET 10 SDK` is installed on CI and developer machines per Plan §Phase 0
- [✓] (2) Runtime/SDK meets minimum requirements (**Verify**)
- [✓] (3) Inspect `global.json` (if present) and confirm it references an SDK that supports `.NET 10` or update it per Plan §Phase 0
- [✓] (4) `global.json` compatible or updated (**Verify**)
- [✓] (5) Inspect `Directory.Build.props`, `Directory.Build.targets`, and `Directory.Packages.props` (if present) for framework/package constraints and confirm compatibility with `.NET 10` per Plan §4 and Plan §5
- [✓] (6) Configuration files compatible with target framework (**Verify**)

### [▶] TASK-002: Atomic framework and package upgrade with compilation fixes
**References**: Plan §Phase 1 (Atomic Upgrade), Plan §4 Project-by-Project Plans, Plan §5 Package Update Reference, Plan §6 Breaking Changes Catalog

- [✓] (1) Update `TargetFramework` to `net10.0-windows10.0.22000.0` in `Ahnenforscherin\Ahnenforscherin.csproj` and update any MSBuild imports (`Directory.Build.props`, `Directory.Build.targets`, `Directory.Packages.props`) as required per Plan §4
- [✓] (2) All project files updated to target framework (**Verify**)
- [✓] (3) Update `PackageReference` entries per Plan §5 (e.g., `Microsoft.EntityFrameworkCore` update) and other package changes referenced in Plan §5
- [✓] (4) All package references updated per Plan §5 (**Verify**)
- [✓] (5) Restore dependencies (`dotnet restore`) for `Ahnenforscherin.slnx`
- [✓] (6) All dependencies restored successfully (**Verify**)
- [✓] (7) Build solution to identify compilation errors (`dotnet build`) and fix all compilation errors found referencing the Breaking Changes Catalog (Plan §6) and Project-by-Project Plans (Plan §4)
- [✓] (8) Rebuild solution to verify fixes applied
- [✓] (9) Solution builds with 0 errors (**Verify**)
- [▶] (10) Commit changes with message: "TASK-002: Atomic upgrade to .NET 10.0 - project & package updates and compilation fixes"

### [ ] TASK-003: Run automated tests and validate upgrade
**References**: Plan §7 Testing & Validation Strategy, Plan §6 Breaking Changes Catalog

- [ ] (1) Run automated test projects listed in Plan §7 (if any) using `dotnet test` per Plan §7
- [ ] (2) Fix any test failures referencing Plan §6 for common breaking-change fixes
- [ ] (3) Re-run tests after fixes
- [ ] (4) All tests pass with 0 failures (**Verify**)



