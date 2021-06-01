import React, { useState } from "react";
import { Button, Card, Checkbox, CircularProgress, Grid, TextField, MenuItem, Select, Typography, FormControl, InputLabel } from "@material-ui/core";
import { Alert, AlertTitle } from "@material-ui/lab";
import { httpGet, httpPost, httpPut } from "../../../api/httpClient";
import ChipInput from 'material-ui-chip-input'
import { useMount } from "../../../lifeCycleExtensions";
import ChipList from "../../../components/Chiplist";
import { useParams } from "react-router";
import { UpdateNCustomerRequestModel } from "../../../api/requestModels/UpdateNCustomerRequestModel"
import { NCustomer } from "../../../api/models/customers/NCustomer";

const UpdateNCustomerPage = () => {

const params = useParams() as { id: string }

	const [submitting, setSubmitting] = useState(false);
	const [loading, setLoading] = useState(false);
	const [loadError, setLoadError] = useState<string>();
	const [error, setError] = useState<string>();
	const [success, setSuccess] = useState(false)

	const [name, setname] = useState<string>("")
	const [vip, setvip] = useState<boolean>(false)
	const [phoneNumber, setphoneNumber] = useState<number>();
	const [points, setpoints] = useState<number>();
	const [loadResult, setLoadResult] = useState<NCustomer>();
	
	useMount(() => {
        load();
    })
    
    const load = async () => {
	            setLoading(true);
	    
	            const result = await httpGet<NCustomer>(`/NCustomer/${params.id}`)
	            if(result.isSuccess) {
	                setLoadResult(result.data)
setname(result.data.name)
setvip(result.data.vip)
setphoneNumber(result.data.phoneNumber)
setpoints(result.data.points)
	            } else {
	                setLoadError(result.message)
	            }
	    
	            setLoading(false);
	        }
	        
	
	const submit = async () => {
        setSubmitting(true);
        setError(undefined);
        setSuccess(false);

        const result = await httpPut<UpdateNCustomerRequestModel>("/NCustomer", {
        	id: params.id,
            name: name, vip: vip, phoneNumber: phoneNumber, points: points
        } as UpdateNCustomerRequestModel);

        if(result.isSuccess) {
        	setSuccess(true);
        } else {
			setError(result.statusCode +": "+ result.message);
        }

        setSubmitting(false);
    }
    
    const isNumber = (n: string | number): boolean => 
	            !isNaN(parseFloat(String(n))) && isFinite(Number(n));
	
	

    const renderBody = () => {
        if(loading) {
            return <div style={{width: "100%"}}><CircularProgress/></div>
        }
	
        return (
            <>
<TextField onChange={(e) => setname(e.target.value)} value={name} type="text" label="name" size="small" variant="outlined"></TextField>                 					
<div style={{padding:"10px"}}/>
<div style={{display: "flex", alignItems: "center"}}>
			                            <Checkbox onChange={e => setvip(e.target.checked)} value={vip}/> vip
			                        </div>
			                        <div style={{padding:"10px"}}/>
<TextField onChange={(e) => setphoneNumber(parseInt(e.target.value))} value={phoneNumber} type="number" label="phoneNumber" size="small" variant="outlined"></TextField>
<div style={{padding:"10px"}}/>
<TextField onChange={(e) => setpoints(parseInt(e.target.value))} value={points} type="number" label="points" size="small" variant="outlined"></TextField>
<div style={{padding:"10px"}}/>
	                    <div style={{padding:"10px"}}/>
	                    {submitting
	                    ? <div style={{width: "100%"}}><CircularProgress/></div>
	                    : <Button onClick={submit} variant="outlined" color="primary">Update</Button>}
            </>       
        )
    }
    
    const render = () => {
        return <div>
                    <Grid container style={{width: "100%", minHeight: "100vh"}} justify="center" alignItems="center">
                        <Grid item xs={10} sm={8} md={6} lg={4} xl={4}>
                            <Card style={{width: "100%", padding: "20px", display: "flex", justifyContent: "center", flexDirection: "column", textAlign: "center"}}> 
                                <Typography style={{paddingBottom: "10px"}} variant="h5">Update NCustomer</Typography>
                                {success
	                            ? <Alert style={{margin: "10px 0"}} severity="success">
	                                <AlertTitle>Success</AlertTitle>
	                                NCustomer was updated successfully
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

export default UpdateNCustomerPage;
