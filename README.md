# Xmip repository template — .NET 11

This repository is the starter snapshot for a .NET 11 Xmip repository. It is not
an Xmip runtime capability.

Use it for anything a person touches: the command line, the PowerShell module,
the MAUI desktop GUI, the Blazor web GUI. ADR-0014: every user-interfacing
module is .NET 11, and `xmip-core-abi` is the exception.

For a Rust module — a capability, a foundation type, a transport — use
[xmip-template-rust](https://github.com/IlleNilsson/xmip-template-rust)
instead.

A repository generated from this template has independent history. Later
template changes do not automatically rewrite generated repositories.

## The one dependency rule

**A .NET repository references `Xmip.Abi` and `Xmip.Surface` by project path,
and no Xmip Rust crate.**

The binding over the normative C header exists once, `dotnet/Xmip.Abi` in
[xmip-core-abi](https://github.com/IlleNilsson/xmip-core-abi) (ADR-0014,
amendment of 2026-09-09), and what every .NET surface builds on it — the
operator surface, the scope tree, runtime discovery, the English, the TOML
reader — is `dotnet/Xmip.Surface` beside it (ADR-0052). A surface is a thin
face over those two. It declares no struct of the header's own, loads no
library itself and turns on no `unsafe`; a surface that did would be a second
binding, which is the drift a shared one exists to prevent.

The reference is a project path inside the composed estate, five levels up
from a project at `module/<provider>/operation/<leaf>/src/<project>/`:

```xml
<ItemGroup>
  <ProjectReference Include="..\..\..\..\..\foundation\abi\dotnet\Xmip.Abi\Xmip.Abi.csproj" />
  <ProjectReference Include="..\..\..\..\..\foundation\abi\dotnet\Xmip.Surface\Xmip.Surface.csproj" />
</ItemGroup>
```

So a surface repository builds inside the estate, where `xgit` builds it; that
is the one place "each repository builds on its own" does not hold, and
ADR-0014 records it rather than leaving it to be discovered.

[xmip-core-cli](https://github.com/IlleNilsson/xmip-core-cli) is the worked
example: argument parsing and rendering over `Xmip.Surface`, linking nothing.

## Before implementation

Follow [TEMPLATE_SETUP.md](TEMPLATE_SETUP.md), and item 3 first. The new
repository must be classified and declared in the authoritative Xmip
architecture manifest before its responsibility or dependencies are treated as
accepted architecture.

## Toolchain

`global.json` pins the SDK for the whole estate, including the preview build
number. Do not change it here — raising it is one deliberate change across every
repository.

`Directory.Build.props` holds the target framework, nullability, analysis level
and warnings-as-errors. A project sets only what is specific to itself.

## Shared governance

Repository-specific licensing remains explicit in [LICENSE](LICENSE).
Contribution, security, support, issue and pull-request defaults are inherited
from [IlleNilsson/.github](https://github.com/IlleNilsson/.github) when they are
not overridden locally.

## Verification

The included workflow is manual-only and calls the versioned shared workflow at
`IlleNilsson/.github@v1`. It does not run on pushes, pull requests or a
schedule.
