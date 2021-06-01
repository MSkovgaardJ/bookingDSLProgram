import React, { useState } from "react";
import { Button, Card, Checkbox, CircularProgress, Grid, TextField, MenuItem, Select, Typography, FormControl, InputLabel } from "@material-ui/core";
import { Alert, AlertTitle } from "@material-ui/lab";
import { httpGet, httpPost } from "../../../api/httpClient";
import ChipInput from 'material-ui-chip-input'
import { useMount } from "../../../lifeCycleExtensions";
import ChipList from "../../../components/Chiplist";
import { CreateRoomRequestModel } from "../../../api/requestModels/CreateRoomRequestModel";

import {RoomSchedule} from "../../../api/models/schedules/RoomSchedule"

const CreateRoomPage = () => {
	
	const [submitting, setSubmitting] = useState(false);
	const [loading, setLoading] = useState(false);
	const [loadError, setLoadError] = useState<string>();
	const [error, setError] = useState<string>();
	const [success, setSuccess] = useState(false)
	
	const [name, setname] = useState<string>("")
	const [capacity, setcapacity] = useState<number>();
	const [normalRoom, setnormalRoom] = useState<boolean>(false)
	const [bookedFrom, setbookedFrom] = useState<number>();
	const [bookedUntil, setbookedUntil] = useState<number>();
	const [plan, setplan] = useState<RoomSchedule[]>([])
	const [planResult, setplanResult] = useState<RoomSchedule[]>([])
	
			useMount(() => {
			        downloadRelationData();
			    })
	
	    const downloadRelationData = async () => {
	    	setLoading(true);
			const planResponse = await httpGet<RoomSchedule[]>("/RoomSchedule")
			if(planResponse.isSuccess) {
				setplanResult(planResponse.data)
			} else {
				setLoadError("Loading failed!")
			}
			
			setLoading(false);
	    }

	const submit = async () => {
        setSubmitting(true);
        setError(undefined);
        setSuccess(false);

        const result = await httpPost<CreateRoomRequestModel>("/Room", {
            name: name, capacity: capacity, normalRoom: normalRoom, bookedFrom: bookedFrom, bookedUntil: bookedUntil, plan: plan
        } as CreateRoomRequestModel);

        if(result.isSuccess) {
setname("")
setcapacity(undefined)
setnormalRoom(false)
setbookedFrom(undefined)
setbookedUntil(undefined)
setplan([])
        	
			setSuccess(true);
        } else {
			setError(result.statusCode +": "+ result.message);
        }

        setSubmitting(false);
    }
    
    const isNumber = (n: string | number): boolean => 
	            !isNaN(parseFloat(String(n))) && isFinite(Number(n));
	
	const updateplan = (item: RoomSchedule, add: boolean) => {
		if(add) {
			plan.push(item);
		} else {
			plan.splice(plan.indexOf(item), 1)
		} 
		setplan([...plan]);
	}
	
	
	const renderBody = () => {
        if(loading) {
            return <div style={{width: "100%"}}><CircularProgress/></div>
        }
	
        return (
            <>
<TextField onChange={(e) => setname(e.target.value)} value={name} type="text" label="name" size="small" variant="outlined"></TextField>                 					
<div style={{padding:"10px"}}/>
<TextField onChange={(e) => setcapacity(parseInt(e.target.value))} value={capacity} type="number" label="capacity" size="small" variant="outlined"></TextField>
<div style={{padding:"10px"}}/>
<div style={{display: "flex", alignItems: "center"}}>
			                            <Checkbox onChange={e => setnormalRoom(e.target.checked)} value={normalRoom}/> normalRoom
			                        </div>
			                        <div style={{padding:"10px"}}/>
<TextField onChange={(e) => setbookedFrom(parseInt(e.target.value))} value={bookedFrom} type="number" label="bookedFrom" size="small" variant="outlined"></TextField>
<div style={{padding:"10px"}}/>
<TextField onChange={(e) => setbookedUntil(parseInt(e.target.value))} value={bookedUntil} type="number" label="bookedUntil" size="small" variant="outlined"></TextField>
<div style={{padding:"10px"}}/>
<ChipList selectedItems={plan.map(e => e.id)} onRemoveItem={(item) => updateplan(plan.filter(e => e.id === item)[0], false)}></ChipList>
<FormControl variant="outlined">
<InputLabel id="demo-simple-select-outlined-label">plan</InputLabel>
<Select variant="outlined" value={''} label={"plan"} onChange={(value) => updateplan(planResult.filter(e => e.id === value.target.value as string)[0], true)}>
									{planResult.filter(f => !plan.map(e => e.id).includes(f.id)).map((ele, key) => {
										return <MenuItem key={key} value={ele.id}>{ele.name}</MenuItem>
									})}
								</Select>
								</FormControl>
								<div style={{padding:"10px"}}/>
	                    <div style={{padding:"10px"}}/>
	                    {submitting
	                    ? <div style={{width: "100%"}}><CircularProgress/></div>
	                    : <Button onClick={submit} variant="outlined" color="primary">Create</Button>}
            </>       
        )
    }
    
    const render = () => {
        return <div>
                    <Grid container style={{width: "100%", minHeight: "100vh"}} justify="center" alignItems="center">
                        <Grid item xs={10} sm={8} md={6} lg={4} xl={4}>
                            <Card style={{width: "100%", padding: "20px", display: "flex", justifyContent: "center", flexDirection: "column", textAlign: "center"}}> 
                                <Typography style={{paddingBottom: "10px"}} variant="h5">Create Room</Typography>
                                {success
	                            ? <Alert style={{margin: "10px 0"}} severity="success">
	                                <AlertTitle>Success</AlertTitle>
	                                Room was created successfully
	                            </Alert>
	                            : null}
	                            {error || loadError
                                ? <Alert style={{margin: "10px 0"}} severity="error">
                                    <AlertTitle>Error</AlertTitle>
                                    {error ? error : loadError}
                                </Alert>
	                            : null}
	                            {loadError 
                                ? null
                                : renderBody()}
                            </Card>
                        </Grid>
                    </Grid>
                </div>
    }

    return render();
}

export default CreateRoomPage;
