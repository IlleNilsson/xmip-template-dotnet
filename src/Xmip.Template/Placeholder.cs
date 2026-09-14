namespace Xmip.Template;

/// <summary>
/// Entry point for an Xmip .NET component.
/// </summary>
/// <remarks>
/// Replace this file only after the repository responsibility, public contracts
/// and dependency direction are accepted in the Xmip architecture.
///
/// Whatever replaces it reaches Xmip through <c>Xmip.Abi</c> and
/// <c>Xmip.Surface</c> in xmip-core-abi, referenced by project path inside
/// the composed estate, and through nothing else. The binding over the C
/// header exists once (ADR-0014, amendment of 2026-09-09) and every .NET
/// surface is a thin face over the shared model (ADR-0052); a surface that
/// crossed the boundary itself, or linked Xmip's Rust, would be evidence
/// that the boundary does not work.
/// </remarks>
public static class Placeholder
{
}
