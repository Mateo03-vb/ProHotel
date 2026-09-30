using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProHotel.API.Migrations
{
    /// <inheritdoc />
    public partial class V01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo_documento = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    numero_documento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    id_empleado = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cedula = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cargo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.id_empleado);
                });

            migrationBuilder.CreateTable(
                name: "servicios",
                columns: table => new
                {
                    id_servicio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    precio = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicios", x => x.id_servicio);
                });

            migrationBuilder.CreateTable(
                name: "tipos_habitacion",
                columns: table => new
                {
                    id_tipo_habitacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    capacidad_personas = table.Column<int>(type: "integer", nullable: false),
                    precio_base_noche = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_habitacion", x => x.id_tipo_habitacion);
                });

            migrationBuilder.CreateTable(
                name: "reservas",
                columns: table => new
                {
                    id_reserva = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fecha_reserva = table.Column<DateTime>(type: "date", nullable: false),
                    fecha_check_in = table.Column<DateTime>(type: "date", nullable: false),
                    fecha_check_out = table.Column<DateTime>(type: "date", nullable: false),
                    estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    monto_total = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    id_cliente = table.Column<int>(type: "integer", nullable: false),
                    id_empleado = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservas", x => x.id_reserva);
                    table.ForeignKey(
                        name: "FK_reservas_clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservas_empleados_id_empleado",
                        column: x => x.id_empleado,
                        principalTable: "empleados",
                        principalColumn: "id_empleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password_hash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    rol = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false),
                    id_empleado = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_usuarios_empleados_id_empleado",
                        column: x => x.id_empleado,
                        principalTable: "empleados",
                        principalColumn: "id_empleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "habitaciones",
                columns: table => new
                {
                    id_habitacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    piso = table.Column<int>(type: "integer", nullable: false),
                    estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    id_tipo_habitacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_habitaciones", x => x.id_habitacion);
                    table.ForeignKey(
                        name: "FK_habitaciones_tipos_habitacion_id_tipo_habitacion",
                        column: x => x.id_tipo_habitacion,
                        principalTable: "tipos_habitacion",
                        principalColumn: "id_tipo_habitacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pagos",
                columns: table => new
                {
                    id_pago = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    monto = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    metodo_pago = table.Column<string>(type: "varchar(30)", nullable: false),
                    fecha_pago = table.Column<DateTime>(type: "date", nullable: false),
                    referencia_transaccion = table.Column<string>(type: "varchar(100)", nullable: false),
                    id_reserva = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagos", x => x.id_pago);
                    table.ForeignKey(
                        name: "FK_pagos_reservas_id_reserva",
                        column: x => x.id_reserva,
                        principalTable: "reservas",
                        principalColumn: "id_reserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalles_reserva",
                columns: table => new
                {
                    id_detalle_reserva = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    precio_noche_pactado = table.Column<decimal>(type: "numeric", nullable: false),
                    id_reserva = table.Column<int>(type: "integer", nullable: false),
                    id_habitacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalles_reserva", x => x.id_detalle_reserva);
                    table.ForeignKey(
                        name: "FK_detalles_reserva_habitaciones_id_habitacion",
                        column: x => x.id_habitacion,
                        principalTable: "habitaciones",
                        principalColumn: "id_habitacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalles_reserva_reservas_id_reserva",
                        column: x => x.id_reserva,
                        principalTable: "reservas",
                        principalColumn: "id_reserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "consumos",
                columns: table => new
                {
                    id_consumo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cantidad = table.Column<int>(type: "integer", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    fecha_consumo = table.Column<DateTime>(type: "date", nullable: false),
                    id_detalle_reserva = table.Column<int>(type: "integer", nullable: false),
                    id_servicio = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consumos", x => x.id_consumo);
                    table.ForeignKey(
                        name: "FK_consumos_detalles_reserva_id_detalle_reserva",
                        column: x => x.id_detalle_reserva,
                        principalTable: "detalles_reserva",
                        principalColumn: "id_detalle_reserva",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_consumos_servicios_id_servicio",
                        column: x => x.id_servicio,
                        principalTable: "servicios",
                        principalColumn: "id_servicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_consumos_id_detalle_reserva",
                table: "consumos",
                column: "id_detalle_reserva");

            migrationBuilder.CreateIndex(
                name: "IX_consumos_id_servicio",
                table: "consumos",
                column: "id_servicio");

            migrationBuilder.CreateIndex(
                name: "IX_detalles_reserva_id_habitacion",
                table: "detalles_reserva",
                column: "id_habitacion");

            migrationBuilder.CreateIndex(
                name: "IX_detalles_reserva_id_reserva",
                table: "detalles_reserva",
                column: "id_reserva");

            migrationBuilder.CreateIndex(
                name: "IX_habitaciones_id_tipo_habitacion",
                table: "habitaciones",
                column: "id_tipo_habitacion");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_id_reserva",
                table: "pagos",
                column: "id_reserva");

            migrationBuilder.CreateIndex(
                name: "IX_reservas_id_cliente",
                table: "reservas",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_reservas_id_empleado",
                table: "reservas",
                column: "id_empleado");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_id_empleado",
                table: "usuarios",
                column: "id_empleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consumos");

            migrationBuilder.DropTable(
                name: "pagos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "detalles_reserva");

            migrationBuilder.DropTable(
                name: "servicios");

            migrationBuilder.DropTable(
                name: "habitaciones");

            migrationBuilder.DropTable(
                name: "reservas");

            migrationBuilder.DropTable(
                name: "tipos_habitacion");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "empleados");
        }
    }
}
