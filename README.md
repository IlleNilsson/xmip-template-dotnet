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

**A .NET repository references `include/xmip_module.h` and no Xmip Rust crate.**

ADR-0012 clause 2 makes the header normative and the language bindings a
convenience. A surface that linked Xmip's Rust would prove the boundary does not
work. That a generated project compiles without a single Xmip source file is the
test, and it is worth keeping true.

[xmip-core-cli](https://github.com/IlleNilsson/xmip-core-cli) is the worked
example: `NativeLibrary.Load`, `xmip_create_module_v1`, the descriptor read back
and the instance destroyed, linking nothing.

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
