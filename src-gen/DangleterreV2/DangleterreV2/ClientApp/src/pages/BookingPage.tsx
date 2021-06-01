import { Accordion, AccordionDetails, AccordionSummary, Button, CircularProgress, Collapse, FormControl, InputLabel, MenuItem, Select, Typography } from "@material-ui/core";
import { ExpandMore } from "@material-ui/icons";
import { Alert, AlertTitle } from "@material-ui/lab";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import { httpGet, httpPost } from "../api/httpClient";
import { useMount } from "../lifeCycleExtensions";
import { CreateRoomBookRequestModel } from "../api/requestModels/CreateRoomBookRequestModel";
import { Room } from "../api/models/resources/Room";
import { RoomSchedule } from "../api/models/schedules/RoomSchedule";
import { NCustomer } from "../api/models/customers/NCustomer";
import { VipCustomer } from "../api/models/customers/VipCustomer";

const BookingPage = () => {
	
	const params = useParams() as { id: string, type: string };
	
	const [loadUser, setLoadUser] = useState(false);
    const [loadUserError, setLoadUserError] = useState<string>()
	const [userNCustomer, setUserNCustomer] = useState<NCustomer>();
	const [userVipCustomer, setUserVipCustomer] = useState<VipCustomer>();
	
	const [loadRoomBookResources, setLoadRoomBookResources] = useState(false);
		    const [loadErrorRoomBookResources, setLoadErrorRoomBookResources] = useState<string>();
		    const [openRoomBookResource, setOpenRoomBookResource] = useState(false);
		    const [RoomBookResource, setRoomBookResource] = useState<Room[]>([]);
		    const [selectedRoomBookResource, setSelectedRoomBookResource] = useState<string>('');
		    const [loadRoomBookResourceSchedules, setLoadRoomBookResourceSchedules] = useState(false);
		    const [loadErrorRoomBookResourceSchedules, setLoadErrorRoomBookResourceSchedules] = useState<string>()
		    const [RoomBookResourceSchedules, setRoomBookResourceSchedules] = useState<RoomSchedule[]>([]);
		    const [selectedRoomBookResourceSchedule, setSelectedRoomBookResourceSchedule] = useState<string>('');
		    const [submittingRoomBook, setSubmittingRoomBook] = useState(false);
		    const [submittingRoomBookError, setSubmittingRoomBookError] = useState<string>();
	
	useMount(() => {
		if(params.type === "NCustomer") {
		            fetchNCustomer();
		        }
		if(params.type === "VipCustomer") {
		            fetchVipCustomer();
		        }
    })
    
    const fetchNCustomer = async () => {
	            setLoadUser(true);
	    
	            var result = await httpGet<NCustomer>(`/NCustomer/${params.id}`)
	            console.log(result)
	            if(result.isSuccess) {
	                setUserNCustomer(result.data);
	            } else {
	                setLoadUserError(result.message);
	            }
	            setLoadUser(false);
	        }
	        
    const fetchVipCustomer = async () => {
	            setLoadUser(true);
	    
	            var result = await httpGet<VipCustomer>(`/VipCustomer/${params.id}`)
	            console.log(result)
	            if(result.isSuccess) {
	                setUserVipCustomer(result.data);
	            } else {
	                setLoadUserError(result.message);
	            }
	            setLoadUser(false);
	        }
	        
    
    const fetchRoomBookResource = async () => {
	            setLoadRoomBookResources(true);
	            setLoadErrorRoomBookResources(undefined);
	    
	            var result = await httpGet<Room[]>("/Room");
	    
	            if(result.isSuccess) {
	                setRoomBookResource(result.data)
	            } else {
	                setLoadErrorRoomBookResources(result.message);
	            }
	    
	            setLoadRoomBookResources(false);
	        }
	    
	        useEffect(() => {
	            fetchRoomBookResourceSchedules();
	        }, [selectedRoomBookResourceSchedule])
	    
	        const fetchRoomBookResourceSchedules = async () => {
	            setLoadRoomBookResourceSchedules(true)
	            setLoadErrorRoomBookResourceSchedules(undefined);
	    
	            var result = await httpGet<RoomSchedule[]>("/RoomSchedule");
	            if(result.isSuccess) {
	                setRoomBookResourceSchedules(result.data);
	            } else {
	                setLoadErrorRoomBookResourceSchedules(result.message);
	            }
	    
	            setLoadRoomBookResourceSchedules(false);
	        }
	        
	        const createRoomBookBooking = async () => {
	            setSubmittingRoomBook(true);
	            setSubmittingRoomBookError(undefined)
	    
	            var result = await httpPost<CreateRoomBookRequestModel>("/RoomBook", {
	                Room: RoomBookResource.filter(e => e.id === selectedRoomBookResource)[0],
	                plan: RoomBookResourceSchedules.filter(e => e.id === selectedRoomBookResourceSchedule)[0],
	                cus: userNCustomer
	            } as CreateRoomBookRequestModel)
	    
	            if(result.isSuccess) {
	                setSelectedRoomBookResource('');
	                setSelectedRoomBookResourceSchedule('')
	            } else {
	                setSubmittingRoomBookError(result.message)
	            }
	    
	            setSubmittingRoomBook(false)
	        }

    const render = () => {
	            return <div style={{display: "flex", width: "100%", justifyContent: "center", flexDirection: "column", padding: "20px"}}>
                    <Typography style={{textAlign: "center", width: "100%"}} variant="h2">Book resources</Typography>
                    <Typography style={{textAlign: "center", width: "100%"}} variant="h4">User: {params.id}, type: {params.type}</Typography>
                    {loadUser
                    ? <div style={{display: "flex", width: "100%", justifyContent: "center"}}><CircularProgress/></div>
                    : loadUserError
                    ? <Alert style={{margin: "10px 0"}} severity="error">
                        <AlertTitle>User load Error:</AlertTitle>
                        {loadUserError}
                    </Alert> 
                    : <div>
                    	<Accordion disabled={"NCustomer" !== params.type} style={{width: "100%"}}>
		                    <AccordionSummary
		                    onClick={() => {
		                        if(!openRoomBookResource)fetchRoomBookResource();
		                        setOpenRoomBookResource(!openRoomBookResource);
		                    }}
		                    expandIcon={<ExpandMore/>}
		                    >
		                        <Typography>RoomBook</Typography>
		                    </AccordionSummary>
		                    <AccordionDetails style={{width: "100%"}}>
		                        <div style={{display: "flex", flexDirection: "column", width: "100%"}}>
		                            {loadRoomBookResources
		                            ? <div style={{display: "flex", width: "100%", justifyContent: "center"}}><CircularProgress/></div>
		                            : loadErrorRoomBookResources 
		                            ? <Alert style={{margin: "10px 0"}} severity="error">
		                                <AlertTitle>Error</AlertTitle>
		                                {loadErrorRoomBookResources}
		                            </Alert> 
		                            : <div style={{width: "100%"}}>
		                                {submittingRoomBookError 
		                                ?<Alert style={{margin: "10px 0"}} severity="error">
		                                    <AlertTitle>Error</AlertTitle>
		                                    {submittingRoomBookError}
		                                </Alert> : null}
		                                <FormControl style={{width: "100%"}} variant="outlined">
		                                    <InputLabel id="demo-simple-select-outlined-label">Room</InputLabel>
		                                    <Select variant="outlined" value={selectedRoomBookResource} label={"Room"} onChange={change => setSelectedRoomBookResource(change.target.value as string)}>
		                                    {RoomBookResource.map((ele, key) => {
		                                        return <MenuItem key={key} value={ele.id}>{ele.name}</MenuItem>
		                                    })}
		                                    </Select>
		                                </FormControl>
		                                <Collapse in={selectedRoomBookResource ? true : false}>
		                                    <div style={{padding: "20px 0"}}>
		                                        {loadRoomBookResourceSchedules
		                                        ? <div style={{display: "flex", width: "100%", justifyContent: "center"}}><CircularProgress/></div>
		                                        : <FormControl style={{width: "100%"}} variant="outlined">
		                                            <InputLabel id="demo-simple-select-outlined-label">RoomSchedule</InputLabel>
		                                            <Select variant="outlined" value={selectedRoomBookResourceSchedule} label={"RoomSchedule"} onChange={change => setSelectedRoomBookResourceSchedule(change.target.value as string)}>
		                                            {RoomBookResource.filter(e => e.id === selectedRoomBookResource)[0]?.plan?.map((ele, key) => {
														return <MenuItem key={key} value={ele.id}>{ele.name}</MenuItem>
													})}
		                                            </Select>
		                                        </FormControl>
		                                        }
		                                        <Collapse in={selectedRoomBookResourceSchedule ? true : false}>
		                                            <div style={{paddingTop: "20px", width: "100%"}}>
		                                                {submittingRoomBook
		                                                ? <div style={{display: "flex", width: "100%", justifyContent: "center"}}><CircularProgress/></div>
		                                                : <Button style={{width: "100%"}} color="primary" variant="outlined" onClick={createRoomBookBooking}>Book RoomBookt</Button>}
		                                            </div>
		                                        </Collapse>
		                                    </div>
		                                </Collapse>
		                            <div style={{padding:"10px"}}/>
		                            </div>}
		                        </div>
		                    </AccordionDetails>
		                </Accordion>
                    </div>}
                </div>
	        }

    return render();
}

export default BookingPage;
