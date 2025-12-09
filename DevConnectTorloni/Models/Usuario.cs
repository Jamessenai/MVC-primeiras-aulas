using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Models;

[Index("Email", Name = "UQ__Usuario__AB6E6164129F22A0", IsUnique = true)]
[Index("NomeUsuario", Name = "UQ__Usuario__CCB80B0AE581F25A", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nome_completo")]
    [StringLength(255)]
    public string NomeCompleto { get; set; } = null!;

    [Column("nome_usuario")]
    [StringLength(50)]
    public string NomeUsuario { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("senha")]
    [StringLength(30)]
    public string Senha { get; set; } = null!;

    [Column("foto_perfil_url")]
    [StringLength(150)]
    public string? FotoPerfilUrl { get; set; }

    [InverseProperty("Usuario")]
    public virtual ICollection<Comentario> Comentario { get; set; } = new List<Comentario>();

    [InverseProperty("Usuario")]
    public virtual ICollection<Curtida> Curtida { get; set; } = new List<Curtida>();

    [InverseProperty("Usuario")]
    public virtual ICollection<Publicacao> Publicacao { get; set; } = new List<Publicacao>();

    [InverseProperty("SeguidorNavigation")]
    public virtual ICollection<Seguidor> SeguidorSeguidorNavigation { get; set; } = new List<Seguidor>();

    [InverseProperty("Usuario")]
    public virtual ICollection<Seguidor> SeguidorUsuario { get; set; } = new List<Seguidor>();
}
