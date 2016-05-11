CREATE PROCEDURE ExcluirClientePorId
(
	@ID_CLIENTE int
)

as

begin
	Delete from CRUD_CLIENTES where ID_CLIENTE = @ID_CLIENTE
end

Create Procedure AtualizarCliente
(
	@ID_CLIENTE int,
	@NOME varchar(100),
	@IDADE int,
	@ENDERECO varchar(100),
	@TELEFONE varchar(100),
	@EMAIL varchar(100),
	@CIDADE varchar(100),
	@UF char(2)
)
as

begin

Update CRUD_CLIENTES set NOME = @NOME, IDADE = @IDADE, ENDERECO = @ENDERECO, TELEFONE = @TELEFONE, EMAIL = @EMAIL, CIDADE = @CIDADE, UF = @UF
WHERE ID_CLIENTE = @ID_CLIENTE

end

Create Procedure IncluirCliente
(	
	@NOME varchar(100),
	@IDADE int,
	@ENDERECO varchar(100),
	@TELEFONE varchar(100),
	@EMAIL varchar(100),
	@CIDADE varchar(100),
	@UF char(2)
)
as

begin
	Insert Into CRUD_CLIENTES values (@NOME, @IDADE, @ENDERECO, @TELEFONE, @EMAIL, @CIDADE, @UF) 
end

Create Procedure ObterCliente

as

begin
	Select ID_CLIENTE, NOME, IDADE, ENDERECO, TELEFONE, EMAIL, CIDADE, UF FROM CRUD_CLIENTES
end



