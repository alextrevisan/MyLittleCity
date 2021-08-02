class_name Constants
const TILE_SIZE:int = 8
const TILE_SIZE_SHIFT:int = 3

const DISPLAY_WIDTH:int = 64
const DISPLAY_HEIGHT:int = 64
const MAP_WIDTH:int = 48
const MAP_HEIGHT:int = 48



const MAX_SCROLL_X:int = (MAP_WIDTH * TILE_SIZE - DISPLAY_WIDTH)
const MAX_SCROLL_Y:int = (MAP_HEIGHT * TILE_SIZE - DISPLAY_HEIGHT)

const VISIBLE_TILES_X:int = ((DISPLAY_WIDTH / TILE_SIZE) + 1)
const VISIBLE_TILES_Y:int = ((DISPLAY_HEIGHT / TILE_SIZE) + 1)

const MAX_BUILDINGS:int = 130

# How long a button has to be held before the first event repeats
const INPUT_REPEAT_TIME:int = 10

# When repeating, how long between each event is fired
const INPUT_REPEAT_FREQUENCY:int = 2

const BULLDOZER_COST:int = 1
const ROAD_COST:int = 10
const POWERLINE_COST:int = 5

const FIRST_TERRAIN_TILE:int = 1
const FIRST_WATER_TILE:int = 17
const LAST_WATER_TILE:int = (FIRST_WATER_TILE + 3)

const FIRST_FIRE_TILE:int = 232
const LAST_FIRE_TILE:int = (FIRST_FIRE_TILE + 3)

const FIRST_ROAD_TILE:int = 5
const FIRST_ROAD_TRAFFIC_TILE:int = (FIRST_ROAD_TILE + 16)
const LAST_ROAD_TRAFFIC_TILE:int = (FIRST_ROAD_TRAFFIC_TILE + 10)
const FIRST_POWERLINE_TILE:int = 53
const FIRST_POWERLINE_ROAD_TILE:int = 49

const FIRST_ROAD_BRIDGE_TILE:int = 32
const FIRST_POWERLINE_BRIDGE_TILE:int = 34

const FIRST_BUILDING_TILE:int = 224

const FIRST_EDGE_TILE:int = 79
const NORTH_WEST_EDGE_TILE:int = FIRST_EDGE_TILE
const NORTH_EAST_EDGE_TILE:int = (FIRST_EDGE_TILE + 16)
const SOUTH_WEST_EDGE_TILE:int = (FIRST_EDGE_TILE + 32)
const SOUTH_EAST_EDGE_TILE:int = (FIRST_EDGE_TILE + 48)

const POWERCUT_TILE:int = 48
const RUBBLE_TILE:int = 51

const FIRST_BRUSH_TILE:int = 240

const NUM_TOOLBAR_BUTTONS:int = 13

const MAX_POPULATION_DENSITY:int = 15

const NUM_TERRAIN_TYPES:int = 3

const STARTING_TAX_RATE:int = 7
const STARTING_FUNDS:int = 10000

const FIRE_AND_POLICE_MAINTENANCE_COST:int = 100
const ROAD_MAINTENANCE_COST:int = 10

const POPULATION_MULTIPLIER:int = 17

const MIN_BUDGET_DISPLAY_TIME:int = 16

const BUILDING_MAX_FIRE_COUNTER:int = 3

const MIN_FRAMES_BETWEEN_DISASTER:int = 2500
const FRAMES_PER_YEAR:int = (MAX_BUILDINGS * 12)
const MIN_TIME_BETWEEN_DISASTERS:int = (FRAMES_PER_YEAR * 2)
const MAX_TIME_BETWEEN_DISASTERS:int = (FRAMES_PER_YEAR * 6)

const DISASTER_MESSAGE_DISPLAY_TIME:int = 60
