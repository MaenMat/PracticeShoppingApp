using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PracticeShoppingApp.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class StockQtyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: new Guid("3f750a30-b50e-4a9c-8d2f-f0d146cbd3c5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: new Guid("50c2f29a-cef8-4ab5-9dce-bf9e1681c08d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: new Guid("6a924b18-5de1-4bdb-a516-a9f30a87e523"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: new Guid("a07a4c64-0a51-4bfa-b96d-01365e99d64d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: new Guid("b49b69c1-9258-44bb-b63b-2db9fd2a6978"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: new Guid("d46b674a-42c2-46e3-a930-7470be9b465a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: new Guid("edec7918-77ff-405a-b586-f648bf2a7335"));

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                columns: new[] { "OrderPlaced", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bf3f3182-7e53-441a-8b7c-f6280be284aa"), 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                columns: new[] { "OrderPlaced", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fe98f549-e791-4e9f-ac26-18c2292a2ee9"), 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                columns: new[] { "OrderPlaced", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fe98f549-e791-4ebf-aa26-04c2292a2ee9"), 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProdId", "CategoryId", "CreatedBy", "CreatedDate", "Description", "ImageUrl", "LastUpdatedBy", "LastUpdatedDate", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("6313149f-7137-473a-a4b5-a5571b43e6a9"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Top-of-the-line smartphone with advanced features.", "https://example.com/smartphone.jpg", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smartphone", 800, 30 },
                    { new Guid("a0098d2f-8003-43c1-92a4-bec76a7c5dde"), new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juicy burger with fresh ingredients.", "https://example.com/burger.jpg", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burger", 8, 100 },
                    { new Guid("b0788d3f-8083-43c1-92a4-eac76a7c5dde"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-performance laptop with the latest technology.", "https://example.com/laptop.jpg", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop", 1000, 15 },
                    { new Guid("bf3f3182-7e53-441a-8b7c-f6280be284aa"), new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comfortable sofa for your living room.", "https://example.com/sofa.jpg", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofa", 500, 10 },
                    { new Guid("fe44f549-e791-4e9f-ac26-18c8892b2fe9"), new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Environmentally friendly electric car with cutting-edge technology.", "https://example.com/electric_car.jpg", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electric Car", 50000, 9 },
                    { new Guid("fe98f549-e791-4e9f-ac26-18c2292a2ee9"), new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delicious pizza with a variety of toppings.", "https://example.com/pizza.jpg", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pizza", 10, 100 },
                    { new Guid("fe98f549-e791-4ebf-aa26-04c2292a2ee9"), new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luxury car with advanced features and performance.", "https://example.com/car.jpg", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Car", 30000, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: new Guid("6313149f-7137-473a-a4b5-a5571b43e6a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: new Guid("a0098d2f-8003-43c1-92a4-bec76a7c5dde"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: new Guid("b0788d3f-8083-43c1-92a4-eac76a7c5dde"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: new Guid("bf3f3182-7e53-441a-8b7c-f6280be284aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: new Guid("fe44f549-e791-4e9f-ac26-18c8892b2fe9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: new Guid("fe98f549-e791-4e9f-ac26-18c2292a2ee9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: new Guid("fe98f549-e791-4ebf-aa26-04c2292a2ee9"));

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2024, 2, 20, 17, 22, 31, 456, DateTimeKind.Local).AddTicks(969));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 2, 20, 17, 22, 31, 456, DateTimeKind.Local).AddTicks(932));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 2, 20, 17, 22, 31, 456, DateTimeKind.Local).AddTicks(957));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedBy", "CreatedDate", "LastUpdatedBy", "LastUpdatedDate", "OrderPaid", "OrderPlaced", "OrderTotal", "UserId" },
                values: new object[,]
                {
                    { new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 2, 20, 17, 22, 31, 456, DateTimeKind.Local).AddTicks(981), 245, new Guid("4ad901be-f447-46dd-bcf7-dbe401afa203") },
                    { new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 2, 20, 17, 22, 31, 456, DateTimeKind.Local).AddTicks(1018), 116, new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c") },
                    { new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 2, 20, 17, 22, 31, 456, DateTimeKind.Local).AddTicks(993), 142, new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c") },
                    { new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 2, 20, 17, 22, 31, 456, DateTimeKind.Local).AddTicks(1006), 40, new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProdId", "CategoryId", "CreatedBy", "CreatedDate", "Description", "ImageUrl", "LastUpdatedBy", "LastUpdatedDate", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("3f750a30-b50e-4a9c-8d2f-f0d146cbd3c5"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Top-of-the-line smartphone with advanced features.", "https://example.com/smartphone.jpg", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smartphone", 800 },
                    { new Guid("50c2f29a-cef8-4ab5-9dce-bf9e1681c08d"), new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luxury car with advanced features and performance.", "https://example.com/car.jpg", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Car", 30000 },
                    { new Guid("6a924b18-5de1-4bdb-a516-a9f30a87e523"), new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juicy burger with fresh ingredients.", "https://example.com/burger.jpg", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burger", 8 },
                    { new Guid("a07a4c64-0a51-4bfa-b96d-01365e99d64d"), new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comfortable sofa for your living room.", "https://example.com/sofa.jpg", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofa", 500 },
                    { new Guid("b49b69c1-9258-44bb-b63b-2db9fd2a6978"), new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delicious pizza with a variety of toppings.", "https://example.com/pizza.jpg", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pizza", 10 },
                    { new Guid("d46b674a-42c2-46e3-a930-7470be9b465a"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-performance laptop with the latest technology.", "https://example.com/laptop.jpg", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop", 1000 },
                    { new Guid("edec7918-77ff-405a-b586-f648bf2a7335"), new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Environmentally friendly electric car with cutting-edge technology.", "https://example.com/electric_car.jpg", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electric Car", 50000 }
                });
        }
    }
}
