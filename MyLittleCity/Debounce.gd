extends Node

var debounceTimers:Dictionary = {}

func _process(delta):
	var currentTime = OS.get_ticks_msec()
	for key in debounceTimers:
		if currentTime - debounceTimers[key] > 300:
			key.call_func()
			debounceTimers[key] = null
			debounceTimers.erase(key)
			
func Debounce(function:FuncRef, time_ms=300):
		debounceTimers[function] = OS.get_ticks_msec()

