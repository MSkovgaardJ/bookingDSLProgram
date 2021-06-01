import {RoomSchedule} from "../models/schedules/RoomSchedule"
export type CreateRoomRequestModel = {
	name: string
	capacity: number
	normalRoom: boolean
	bookedFrom: number
	bookedUntil: number
	plan: RoomSchedule[]
} 
