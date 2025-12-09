using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Models;

public partial class Comentario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("usuarioid")]
    public int Usuarioid { get; set; }

    [Column("publicacaoid")]
    public int Publicacaoid { get; set; }

    [Column("texto")]
    [StringLength(255)]
    public string Texto { get; set; } = null!;

    [Column("data_comentario")]
    public DateOnly DataComentario { get; set; }

    [ForeignKey("Publicacaoid")]
    [InverseProperty("Comentario")]
    public virtual Publicacao Publicacao { get; set; } = null!;

    [ForeignKey("Usuarioid")]
    [InverseProperty("Comentario")]
    public virtual Usuario Usuario { get; set; } = null!;
}
