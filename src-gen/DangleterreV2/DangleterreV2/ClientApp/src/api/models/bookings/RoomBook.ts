import {Room} from "../resources/Room"
import {RoomSchedule} from "../schedules/RoomSchedule"
import {NCustomer} from "../customers/NCustomer"

export type RoomBook = {
	id: string
	name: string
	Room: Room
	plan: RoomSchedule
	cus: NCustomer
} 
