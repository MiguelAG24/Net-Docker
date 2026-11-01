using System.ComponentModel.DataAnnotations;

namespace BlazorEmpresa.Models;

public class Cliente
{
    public int id_cliente { get; set; }

    [Required(ErrorMessage = "El CUI es obligatorio.")]
    [RegularExpression(@"^\d{13}$", ErrorMessage = "El CUI debe contener exactamente 13 dígitos.")]
    public string? cui { get; set; }

    [Required(ErrorMessage = "El NIT es obligatorio.")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "El NIT debe contener entre 2 y 20 caracteres.")]
    public string? nit { get; set; }

    [Required(ErrorMessage = "Los nombres son obligatorios.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Los nombres deben contener entre 2 y 100 caracteres.")]
    public string? nombres { get; set; }

    [Required(ErrorMessage = "Los apellidos son obligatorios.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Los apellidos deben contener entre 2 y 100 caracteres.")]
    public string? apellidos { get; set; }

    [Required(ErrorMessage = "La dirección es obligatoria.")]
    [StringLength(200, MinimumLength = 5, ErrorMessage = "La dirección debe contener entre 5 y 200 caracteres.")]
    public string? direccion { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    [RegularExpression(@"^[0-9\-\+\s]{8,15}$", ErrorMessage = "Ingrese un número de teléfono válido.")]
    public string? telefono { get; set; }

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
[CustomValidation(typeof(Cliente), nameof(ValidarFechaNacimiento))]
public DateTime? fecha_nacimiento { get; set; }

public static ValidationResult? ValidarFechaNacimiento(
    DateTime? fecha,
    ValidationContext context)
{
    if (!fecha.HasValue)
        return ValidationResult.Success;

    if (fecha.Value.Date > DateTime.Today)
        return new ValidationResult(
            "La fecha de nacimiento no puede ser futura."
        );

    return ValidationResult.Success;
}
}