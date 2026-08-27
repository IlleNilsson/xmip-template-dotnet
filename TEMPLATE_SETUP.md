# Template setup

Complete this checklist before implementation.

**Item 3 is the one that gets skipped.** On 2026-08-26 eight repositories in the
estate were still called `xmip-template` — including two carrying more than
seven hundred lines of working code. Nothing that depended on two of them could
build, and the cause was invisible because each repository compiled fine on its
own.

1. Choose the final repository name and confirm that its boundary belongs in the
   Xmip architecture. Under ADR-0011 a surface module is
   `xmip-<provider>-<surface>` and stops at the provider, because there is no
   external standard to name.
2. Update the architecture specification and the architecture manifest together
   when the new repository changes the architecture baseline.
3. **Rename `src/Xmip.Template`** — the directory, the `.csproj`,
   `RootNamespace`, `AssemblyName` and the namespace in every file. The
   assembly name must match the repository.
4. Replace the template title and instructions in `README.md`.
5. Complete `ARCHITECTURE.md`: classification, maturity, owning capability,
   responsibility, public contracts, dependencies and non-responsibilities.
6. Keep the full AGPL-3.0 licence in `LICENSE` and the
   `PackageLicenseExpression` in `Directory.Build.props`.
7. Add verification that proves the repository's accepted responsibility and
   contracts.
8. Keep account-wide contribution, security, support, issue and pull-request
   defaults unless a reviewed repository-specific override is required.
9. Decide explicitly whether automatic verification triggers should be enabled.
   The template includes manual dispatch only.
10. Leave `global.json` alone. It is the estate's SDK, not this repository's
    preference.
11. Remove this setup file after every item is complete.

## Reaching Xmip

Through `include/xmip_module.h` in
[xmip-core-abi](https://github.com/IlleNilsson/xmip-core-abi), and through
nothing else. No `PackageReference` to an Xmip package, no project reference
across repositories, and no Rust.

Crossing the boundary needs raw structs and function pointers, so the project
that does it turns on unsafe explicitly:

```xml
<PropertyGroup>
  <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
</PropertyGroup>
```

`Directory.Build.props` leaves it off, so a project that does not cross the
boundary cannot quietly acquire it.

Two rules the header states and the compiler will not enforce:

- **Nothing throws across the boundary.** A managed exception unwinding into C
  is undefined behaviour, exactly as a Rust panic is. Every
  `[UnmanagedCallersOnly]` callback catches its own.
- **Borrowed means borrowed.** An `XmipStr` is valid for the duration of the
  call that produced it. Copy out of it; never hold the pointer.

## This is a snapshot

Template repositories do not propagate. A change made here after a repository is
generated does not reach that repository, which is why `Sync-XmipEstate` checks
these invariants rather than trusting that the template established them.
