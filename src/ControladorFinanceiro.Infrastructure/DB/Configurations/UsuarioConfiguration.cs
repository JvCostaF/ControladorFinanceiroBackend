using System;
using ControladorFinanceiro.Domain.Entities;
using ControladorFinanceiro.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControladorFinanceiro.Infrastructure.DB.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Nome)
            .IsRequired()
            .HasMaxLength(100);

        /*
        Precisamos do OwnsOne pois estamos lidando com um Value Object. Dessa forma o EF consegue entender isso.
        */
        builder.OwnsOne(u => u.Email, email =>
        {
            email.Property(e => e.Endereco)
                 .HasColumnName("Email")
                 .IsRequired();
        });

        builder.Property(u => u.SenhaHash)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.CreateAt)
            .HasDefaultValueSql("NOW()")
            .IsRequired();
    }
}
