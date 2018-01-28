Feature: CommaSeparatedValueMapping

Scenario: Map comma separated string to IEnumerable<string>
	When I map following table to a set of shipping info
	| ShipCode    | ZipCode | SupplierId | CreatedTime | OrderNumbers                                    |
	| 00000000001 | 200     | 551        | 2017-12-12  | RM0000000000001                                 |
	| 00000000002 | 200     | 551        | 2017-12-12  | RM0000000000002,RM0000000000003                 |
	| 00000000003 | 200     | 551        | 2017-12-12  | RM0000000000001,RM0000000000002,RM0000000000003 |
	| 00000000004 | 200     | 551        | 2017-12-12  | RM0000000000004                                 |
	Then the order numbers for ship code "00000000003" should be
	| value           |
	| RM0000000000001 |
	| RM0000000000002 |
	| RM0000000000003 |
