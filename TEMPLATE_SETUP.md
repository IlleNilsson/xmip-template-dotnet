# Template setup

Complete this checklist before implementation.

**Item 3 is the one that gets skipped.** On 2026-08-26 eight repositories in the
estate were still called `xmip-template` — including two carrying more than
seven hundred lines of working code. Nothing that depended on two of them could
build, and the cause was invisible because each repository compiled fine on its
own.

1. Choose the final repository name. The grammar of a name, including why a
   surface module stops at the provider, is `doc/architecture/repository-model.md`
   section 2 in the estate, and the manifest path is the name.
2. Declare the repository in `architecture.toml` in the same change as the
   models and records it affects: `doc/governance/architectural-change-permission.md`,
   *Estate changes are atomic*.
3. **Rename `src/Xmip.Template`** — the directory, the `.csproj`,
   `RootNamespace`, `AssemblyName` and the namespace in every file. The
   assembly name must match the repository.
4. Replace the template title and instructions in `README.md`.
5. Complete `ARCHITECTURE.md`: classification, maturity, owning capability,
   responsibility, public contracts, dependencies and non-responsibilities.
6. Keep the full AGPL-3.0 license in `LICENSE` and the
   `PackageLicenseExpression` in `Directory.Build.props`.
7. Add verification that proves the repository's accepted responsibility and
   contracts.
8. Inherit the shared governance defaults as `README.md`, *Shared governance*,
   says; an override is a reviewed change.
9. Decide explicitly whether automatic verification triggers are enabled; the
   workflow is manual-only as generated (`README.md`, *Verification*), and
   `automaticVerification` in `architecture.toml` is the estate's default.
10. Leave `global.json` alone. It is the estate's SDK, not this repository's
    preference.
11. Remove this setup file after every item is complete.

## Reaching Xmip

Through `Xmip.Abi` and `Xmip.Surface` in
[xmip-core-abi](https://github.com/IlleNilsson/xmip-core-abi), referenced by
project path inside the composed estate, and through nothing else. No
`PackageReference` to an Xmip package, no binding of the header's own, no
`unsafe`, and no Rust. The `.csproj` carries the two references commented
out; uncomment them once the repository is mounted at
`module/<provider>/operation/<leaf>` (ADR-0014, amendment of 2026-09-09; ADR-0052).

What a surface then does is the PowerShell shape, the command shape or the
screen: it reads `IOperatorSurface`, says things through `English`, and
decides from records, never from the sentences it renders (ADR-0052 clause
4). Anything several surfaces would need goes up to `Xmip.Surface`, where they
all already depend (ADR-0044).

## This is a snapshot

Template repositories do not propagate. A change made here after a repository is
generated does not reach that repository, which is why `Sync-XmipEstate` checks
these invariants rather than trusting that the template established them.
