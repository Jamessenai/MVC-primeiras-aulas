using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Models;

public partial class Publicacao
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("usuarioid")]
    public int? Usuarioid { get; set; }

    [StringLength(255)]
    public string Descricao { get; set; } = null!;

    [Column("imagem_url")]
    [StringLength(255)]
    public string? ImagemUrl { get; set; }

    [Column("data_publicacao")]
    public DateOnly DataPublicacao { get; set; }

    [InverseProperty("Publicacao")]
    public virtual ICollection<Comentario> Comentario { get; set; } = new List<Comentario>();

    [InverseProperty("Publicacao")]
    public virtual ICollection<Curtida> Curtida { get; set; } = new List<Curtida>();

    [ForeignKey("Usuarioid")]
    [InverseProperty("Publicacao")]
    public virtual Usuario? Usuario { get; set; }
}
