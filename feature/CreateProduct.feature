Feature: CreateNewProduct
			As an user
			I want to open an application
			and to create new product

			Scenario: Create new product

			Given I open "http://localhost:5000/" url
			When I send "user" in Name-field and "user" Password-field			
			When I click button Submit
			When I click  reference allProducts
			When I click  button createNew
			When I send "kvas" in ProductName-field
			When I select "Beverages" in Category-field
			When I select "Pavlova, Ltd." in Supplier-field
			When I send "45" in UnitPrice-field
			When I click Submitbutton
			When I click NowMadeProductReference 
			Then  ProductName should be "kvas"
			Then  Category should be "Beverages"
			Then  Supplier should be "Pavlova, Ltd."
			Then  UnitPrice should be "45,0000"