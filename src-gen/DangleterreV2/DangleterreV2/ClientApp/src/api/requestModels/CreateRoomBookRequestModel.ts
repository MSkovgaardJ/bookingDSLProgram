import {Room} from "../models/resources/Room"
import {RoomSchedule} from "../models/schedules/RoomSchedule"
import {NCustomer} from "../models/customers/NCustomer"
export type CreateRoomBookRequestModel = {
	name: string
	Room: Room
	plan: RoomSchedule
	cus: NCustomer
} 
