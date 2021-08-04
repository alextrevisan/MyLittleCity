class_name Constants

const LOW_DENSITY_RESIDENTIAL:int = 0
const LOW_DENSITY_COMERCIAL:int = 1
const LOW_DENSITY_INDUSTRIAL:int = 2
const ROAD:int = 3
const REMOVE_TILE:int = 4

const BuildPrices:Dictionary = {
	LOW_DENSITY_RESIDENTIAL : 0,
	LOW_DENSITY_COMERCIAL : 0,
	LOW_DENSITY_INDUSTRIAL : 0,
	ROAD : 200,
	REMOVE_TILE : 50,
	5:0,
	6:0,
	7:0,
	8:0,
	9:0,
	10:0,
}

const Upkeep:Dictionary = {
	LOW_DENSITY_RESIDENTIAL : 0,
	LOW_DENSITY_COMERCIAL : 0,
	LOW_DENSITY_INDUSTRIAL : 0,
	ROAD : 1,
	REMOVE_TILE : 0,
	5:0,
	6:0,
	7:0,
	8:0,
	9:0,
	10:0,
}

const BuildTilesIndex:Dictionary = {
	LOW_DENSITY_RESIDENTIAL : 2,
	LOW_DENSITY_COMERCIAL : 3,
	LOW_DENSITY_INDUSTRIAL : 1,
	ROAD : 0,
	REMOVE_TILE : -1 
}

const BuildTilesOffset:Dictionary = {
	LOW_DENSITY_RESIDENTIAL : Vector2(0,0),
	LOW_DENSITY_COMERCIAL : Vector2(0,0),
	LOW_DENSITY_INDUSTRIAL : Vector2(0,0),
	ROAD : Vector2(3,0),
	REMOVE_TILE : Vector2(0,0)
}

const Months:Dictionary = {
	0 : "Jan",
	1 : "Fev",
	2 : "Mar",
	3 : "Apr",
	4 : "May",
	5 : "Jun",
	6 : "Jul",
	7 : "Aug",
	8 : "Sep",
	9 : "Oct",
	10 : "Nov",
	11 : "Dec",
}

const HOUSE_1x1 = 1
const HOUSE_1x2 = 2
const HOUSE_2x2 = 3
