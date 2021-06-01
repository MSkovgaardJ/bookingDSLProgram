import {RoomSchedule} from "../schedules/RoomSchedule"

export type Room = {
	id: string
	name: string
	capacity: number
	normalRoom: boolean
	bookedFrom: number
	bookedUntil: number
	plan: RoomSchedule[]
} 
