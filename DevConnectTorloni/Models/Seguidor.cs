using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnectTorloni.Models;

public partial class Seguidor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("usuarioid")]
    public int Usuarioid { get; set; }

    [Column("seguidorid")]
    public int Seguidorid { get; set; }

    [ForeignKey("Seguidorid")]
    [InverseProperty("SeguidorSeguidorNavigation")]
    public virtual Usuario SeguidorNavigation { get; set; } = null!;

    [ForeignKey("Usuarioid")]
    [InverseProperty("SeguidorUsuario")]
    public virtual Usuario Usuario { get; set; } = null!;
}
