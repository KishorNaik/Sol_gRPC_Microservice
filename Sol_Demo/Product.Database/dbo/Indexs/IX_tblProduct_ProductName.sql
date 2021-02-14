CREATE UNIQUE NONCLUSTERED INDEX [IX_tblProduct_ProductName]
	ON [dbo].Products
	(ProductName)
	INCLUDE
	(
		UnitPrice
	)
