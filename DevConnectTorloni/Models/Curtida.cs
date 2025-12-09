using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Models;

[Index("Usuarioid", "Publicacaoid", Name = "UQ__Curtida__EC06FB0AA1DAFFFA", IsUnique = true)]
public partial class Curtida
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("usuarioid")]
    public int Usuarioid { get; set; }

    [Column("publicacaoid")]
    public int Publicacaoid { get; set; }

    [ForeignKey("Publicacaoid")]
    [InverseProperty("Curtida")]
    public virtual Publicacao Publicacao { get; set; } = null!;

    [ForeignKey("Usuarioid")]
    [InverseProperty("Curtida")]
    public virtual Usuario Usuario { get; set; } = null!;
}
