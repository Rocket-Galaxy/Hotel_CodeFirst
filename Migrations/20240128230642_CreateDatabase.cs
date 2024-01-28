using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Codigo_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Cliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nacionalidade_Cliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Codigo_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "ContasReserva",
                columns: table => new
                {
                    Codigo_ContaReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorGasto_ContaReserva = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasReserva", x => x.Codigo_ContaReserva);
                });

            migrationBuilder.CreateTable(
                name: "Filiais",
                columns: table => new
                {
                    Codigo_Filial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Filial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroQuartos_Filial = table.Column<int>(type: "int", nullable: false),
                    Endereco_Filial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeEstrelas_Filial = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiais", x => x.Codigo_Filial);
                });

            migrationBuilder.CreateTable(
                name: "Frigobares",
                columns: table => new
                {
                    Codigo_Frigobar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_ItemFrigobar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Preco_ItemFrigobar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frigobares", x => x.Codigo_Frigobar);
                });

            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    Codigo_Restaurante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_ItemMenu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Preco_ItemMenu = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.Codigo_Restaurante);
                });

            migrationBuilder.CreateTable(
                name: "ServicosLavanderia",
                columns: table => new
                {
                    Codigo_ServicoLavanderia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao_ServicoLavanderia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Preco_ServicoLavanderia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicosLavanderia", x => x.Codigo_ServicoLavanderia);
                });

            migrationBuilder.CreateTable(
                name: "TipoFuncionarios",
                columns: table => new
                {
                    Codigo_TipoFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc_TipoFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoFuncionarios", x => x.Codigo_TipoFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "TipoPagementos",
                columns: table => new
                {
                    Codigo_TipoPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc_TipoPagamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagementos", x => x.Codigo_TipoPagamento);
                });

            migrationBuilder.CreateTable(
                name: "TipoQuartos",
                columns: table => new
                {
                    Codigo_TipoQuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc_TipoQuarto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Valor_TipoQuarto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoQuartos", x => x.Codigo_TipoQuarto);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Codigo_Email = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_Cliente = table.Column<int>(type: "int", nullable: false),
                    Endereco_Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Codigo_Email);
                    table.ForeignKey(
                        name: "FK_Emails_Clientes_Codigo_Cliente",
                        column: x => x.Codigo_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "Codigo_Cliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Codigo_Endereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_Cliente = table.Column<int>(type: "int", nullable: false),
                    Rua_Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numero_Endereco = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Complemento_Endereco = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Bairro_Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cidade_Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado_Endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pais_Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Codigo_Endereco);
                    table.ForeignKey(
                        name: "FK_Enderecos_Clientes_Codigo_Cliente",
                        column: x => x.Codigo_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "Codigo_Cliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Codigo_Telefone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Codigo_Cliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Codigo_Telefone);
                    table.ForeignKey(
                        name: "FK_Telefones_Clientes_Codigo_Cliente",
                        column: x => x.Codigo_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "Codigo_Cliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumoFrigobares",
                columns: table => new
                {
                    Codigo_ConsumoFrigobar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Codigo_ContaReserva = table.Column<int>(type: "int", nullable: false),
                    Codigo_Frigobar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumoFrigobares", x => x.Codigo_ConsumoFrigobar);
                    table.ForeignKey(
                        name: "FK_ConsumoFrigobares_ContasReserva_Codigo_ContaReserva",
                        column: x => x.Codigo_ContaReserva,
                        principalTable: "ContasReserva",
                        principalColumn: "Codigo_ContaReserva",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsumoFrigobares_Frigobares_Codigo_Frigobar",
                        column: x => x.Codigo_Frigobar,
                        principalTable: "Frigobares",
                        principalColumn: "Codigo_Frigobar",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumoRestaurantes",
                columns: table => new
                {
                    Codigo_ConsumoRestaurante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    EntregueNoQuarto = table.Column<bool>(type: "bit", nullable: false),
                    Codigo_ContaReserva = table.Column<int>(type: "int", nullable: false),
                    Codigo_Restaurante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumoRestaurantes", x => x.Codigo_ConsumoRestaurante);
                    table.ForeignKey(
                        name: "FK_ConsumoRestaurantes_ContasReserva_Codigo_ContaReserva",
                        column: x => x.Codigo_ContaReserva,
                        principalTable: "ContasReserva",
                        principalColumn: "Codigo_ContaReserva",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsumoRestaurantes_Restaurantes_Codigo_Restaurante",
                        column: x => x.Codigo_Restaurante,
                        principalTable: "Restaurantes",
                        principalColumn: "Codigo_Restaurante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumosLavanderia",
                columns: table => new
                {
                    Codigo_ConsumoLavanderia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Codigo_ContaReserva = table.Column<int>(type: "int", nullable: false),
                    Codigo_ServicoLavanderia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumosLavanderia", x => x.Codigo_ConsumoLavanderia);
                    table.ForeignKey(
                        name: "FK_ConsumosLavanderia_ContasReserva_Codigo_ContaReserva",
                        column: x => x.Codigo_ContaReserva,
                        principalTable: "ContasReserva",
                        principalColumn: "Codigo_ContaReserva",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsumosLavanderia_ServicosLavanderia_Codigo_ServicoLavanderia",
                        column: x => x.Codigo_ServicoLavanderia,
                        principalTable: "ServicosLavanderia",
                        principalColumn: "Codigo_ServicoLavanderia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Codigo_Funcionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Funcionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo_TipoFuncionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Codigo_Funcionario);
                    table.ForeignKey(
                        name: "FK_Funcionarios_TipoFuncionarios_Codigo_TipoFuncionario",
                        column: x => x.Codigo_TipoFuncionario,
                        principalTable: "TipoFuncionarios",
                        principalColumn: "Codigo_TipoFuncionario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscais",
                columns: table => new
                {
                    Codigo_NotaFiscal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_NotaFiscal = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Data_NotaFiscal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotal_NotaFiscal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Codigo_TipoPagamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscais", x => x.Codigo_NotaFiscal);
                    table.ForeignKey(
                        name: "FK_NotaFiscais_TipoPagementos_Codigo_TipoPagamento",
                        column: x => x.Codigo_TipoPagamento,
                        principalTable: "TipoPagementos",
                        principalColumn: "Codigo_TipoPagamento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quartos",
                columns: table => new
                {
                    Numero_Quarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_Filial = table.Column<int>(type: "int", nullable: false),
                    Codigo_TipoQuarto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartos", x => x.Numero_Quarto);
                    table.ForeignKey(
                        name: "FK_Quartos_Filiais_Codigo_Filial",
                        column: x => x.Codigo_Filial,
                        principalTable: "Filiais",
                        principalColumn: "Codigo_Filial",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quartos_TipoQuartos_Codigo_TipoQuarto",
                        column: x => x.Codigo_TipoQuarto,
                        principalTable: "TipoQuartos",
                        principalColumn: "Codigo_TipoQuarto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Codigo_Reserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicio_Reserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim_Reserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelada_Reserva = table.Column<bool>(type: "bit", nullable: false),
                    Numero_Quarto = table.Column<int>(type: "int", nullable: false),
                    Codigo_ContaReserva = table.Column<int>(type: "int", nullable: true),
                    Codigo_NotaFiscal = table.Column<int>(type: "int", nullable: true),
                    Codigo_Cliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Codigo_Reserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_Codigo_Cliente",
                        column: x => x.Codigo_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "Codigo_Cliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_ContasReserva_Codigo_ContaReserva",
                        column: x => x.Codigo_ContaReserva,
                        principalTable: "ContasReserva",
                        principalColumn: "Codigo_ContaReserva",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_ContasReserva_Codigo_NotaFiscal",
                        column: x => x.Codigo_NotaFiscal,
                        principalTable: "ContasReserva",
                        principalColumn: "Codigo_ContaReserva",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Reservas_Quartos_Numero_Quarto",
                        column: x => x.Numero_Quarto,
                        principalTable: "Quartos",
                        principalColumn: "Numero_Quarto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoFrigobares_Codigo_ContaReserva",
                table: "ConsumoFrigobares",
                column: "Codigo_ContaReserva");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoFrigobares_Codigo_Frigobar",
                table: "ConsumoFrigobares",
                column: "Codigo_Frigobar");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoRestaurantes_Codigo_ContaReserva",
                table: "ConsumoRestaurantes",
                column: "Codigo_ContaReserva");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoRestaurantes_Codigo_Restaurante",
                table: "ConsumoRestaurantes",
                column: "Codigo_Restaurante");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumosLavanderia_Codigo_ContaReserva",
                table: "ConsumosLavanderia",
                column: "Codigo_ContaReserva");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumosLavanderia_Codigo_ServicoLavanderia",
                table: "ConsumosLavanderia",
                column: "Codigo_ServicoLavanderia");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_Codigo_Cliente",
                table: "Emails",
                column: "Codigo_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_Codigo_Cliente",
                table: "Enderecos",
                column: "Codigo_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_Codigo_TipoFuncionario",
                table: "Funcionarios",
                column: "Codigo_TipoFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscais_Codigo_TipoPagamento",
                table: "NotaFiscais",
                column: "Codigo_TipoPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Quartos_Codigo_Filial",
                table: "Quartos",
                column: "Codigo_Filial");

            migrationBuilder.CreateIndex(
                name: "IX_Quartos_Codigo_TipoQuarto",
                table: "Quartos",
                column: "Codigo_TipoQuarto");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_Codigo_Cliente",
                table: "Reservas",
                column: "Codigo_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_Codigo_ContaReserva",
                table: "Reservas",
                column: "Codigo_ContaReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_Codigo_NotaFiscal",
                table: "Reservas",
                column: "Codigo_NotaFiscal");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_Numero_Quarto",
                table: "Reservas",
                column: "Numero_Quarto");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_Codigo_Cliente",
                table: "Telefones",
                column: "Codigo_Cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumoFrigobares");

            migrationBuilder.DropTable(
                name: "ConsumoRestaurantes");

            migrationBuilder.DropTable(
                name: "ConsumosLavanderia");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "NotaFiscais");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Frigobares");

            migrationBuilder.DropTable(
                name: "Restaurantes");

            migrationBuilder.DropTable(
                name: "ServicosLavanderia");

            migrationBuilder.DropTable(
                name: "TipoFuncionarios");

            migrationBuilder.DropTable(
                name: "TipoPagementos");

            migrationBuilder.DropTable(
                name: "ContasReserva");

            migrationBuilder.DropTable(
                name: "Quartos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Filiais");

            migrationBuilder.DropTable(
                name: "TipoQuartos");
        }
    }
}
