Feature: 01-簡化Step參數的對應

@BindAsString
#@BindAsStepArgument
Scenario: 01-簡化Step參數的對應
	Given 在 VirtualTableNames 加入一筆資料 "CartGroup"
	And 在 VirtualTableNames 加入一筆資料 "Cart"
	And 在 VirtualTableNames 加入一筆資料 "Process"
	When 取得 VirtualTableNames 的所有資料
	Then 結果應該包含 "CartGroup,Cart,Process"
	And 結果不應該包含 "Supplier,Product"
