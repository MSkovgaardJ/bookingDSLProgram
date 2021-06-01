import {RoomSchedule} from "../models/schedules/RoomSchedule"
export type UpdateRoomRequestModel = {
	id: string
	name: string
	capacity: number
	normalRoom: boolean
	bookedFrom: number
	bookedUntil: number
	plan: RoomSchedule[]
} 
