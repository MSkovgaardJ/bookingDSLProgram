import { Accordion, AccordionDetails, AccordionSummary, Button, Typography } from "@material-ui/core";
import { ExpandMore } from "@material-ui/icons";
import React from "react";
import { useHistory } from "react-router";

const ResourceOverviewPage = () => {

    const history = useHistory();

    const render = () => {

        return <div style={{display: "flex", width: "100%", justifyContent: "center", flexDirection: "column", padding: "20px"}}>
            <Typography style={{textAlign: "center", width: "100%"}} variant="h2">System Resources</Typography>
<Accordion>
    		                <AccordionSummary
    		                expandIcon={<ExpandMore/>}
    		                >
    		                    <Typography>Spas</Typography>
    		                </AccordionSummary>
    		                <AccordionDetails>
    		                    <div style={{display: "flex", flexDirection: "column"}}>
    		                        <Typography>
    		                            Resource description goes here, manage Spas below:
    		                        </Typography>
    		                        <div style={{paddingTop: "20px", display: "flex"}}>
    		                            <Button onClick={() => history.push("/management/Spa_create")} variant="outlined" color="primary">Create Spa</Button>
                                        <div style={{paddingRight: "10px"}}></div>
                                        <Button onClick={() => history.push("/management/Spas_overview")} variant="outlined" color="primary">Spas Overview</Button>
    		                        </div>
    		                    </div>
    		                </AccordionDetails>
    		            </Accordion>
    		    	<Accordion>
    		                <AccordionSummary
    		                expandIcon={<ExpandMore/>}
    		                >
    		                    <Typography>Rooms</Typography>
    		                </AccordionSummary>
    		                <AccordionDetails>
    		                    <div style={{display: "flex", flexDirection: "column"}}>
    		                        <Typography>
    		                            Resource description goes here, manage Rooms below:
    		                        </Typography>
    		                        <div style={{paddingTop: "20px", display: "flex"}}>
    		                            <Button onClick={() => history.push("/management/Room_create")} variant="outlined" color="primary">Create Room</Button>
                                        <div style={{paddingRight: "10px"}}></div>
                                        <Button onClick={() => history.push("/management/Rooms_overview")} variant="outlined" color="primary">Rooms Overview</Button>
    		                        </div>
    		                    </div>
    		                </AccordionDetails>
    		            </Accordion>	    		
    		    	<Accordion>
    		                <AccordionSummary
    		                expandIcon={<ExpandMore/>}
    		                >
    		                    <Typography>Suites</Typography>
    		                </AccordionSummary>
    		                <AccordionDetails>
    		                    <div style={{display: "flex", flexDirection: "column"}}>
    		                        <Typography>
    		                            Resource description goes here, manage Suites below:
    		                        </Typography>
    		                        <div style={{paddingTop: "20px", display: "flex"}}>
    		                            <Button onClick={() => history.push("/management/Suite_create")} variant="outlined" color="primary">Create Suite</Button>
                                        <div style={{paddingRight: "10px"}}></div>
                                        <Button onClick={() => history.push("/management/Suites_overview")} variant="outlined" color="primary">Suites Overview</Button>
    		                        </div>
    		                    </div>
    		                </AccordionDetails>
    		            </Accordion>	    		
<Accordion>
			                <AccordionSummary
			                expandIcon={<ExpandMore/>}
			                >
			                    <Typography>NCustomers</Typography>
			                </AccordionSummary>
			                <AccordionDetails>
			                    <div style={{display: "flex", flexDirection: "column"}}>
			                        <Typography>
			                            Resource description goes here, manage NCustomers below:
			                        </Typography>
			                        <div style={{paddingTop: "20px", display: "flex"}}>
			                            <Button onClick={() => history.push("/management/NCustomer_create")} variant="outlined" color="primary">Create NCustomer</Button>
                                        <div style={{paddingRight: "10px"}}></div>
                                        <Button onClick={() => history.push("/management/NCustomers_overview")} variant="outlined" color="primary">NCustomers Overview</Button>
			                        </div>
			                    </div>
			                </AccordionDetails>
			            </Accordion>	
<Accordion>
			                <AccordionSummary
			                expandIcon={<ExpandMore/>}
			                >
			                    <Typography>VipCustomers</Typography>
			                </AccordionSummary>
			                <AccordionDetails>
			                    <div style={{display: "flex", flexDirection: "column"}}>
			                        <Typography>
			                            Resource description goes here, manage VipCustomers below:
			                        </Typography>
			                        <div style={{paddingTop: "20px", display: "flex"}}>
			                            <Button onClick={() => history.push("/management/VipCustomer_create")} variant="outlined" color="primary">Create VipCustomer</Button>
                                        <div style={{paddingRight: "10px"}}></div>
                                        <Button onClick={() => history.push("/management/VipCustomers_overview")} variant="outlined" color="primary">VipCustomers Overview</Button>
			                        </div>
			                    </div>
			                </AccordionDetails>
			            </Accordion>	
<Accordion>
			                <AccordionSummary
			                expandIcon={<ExpandMore/>}
			                >
			                    <Typography>RoomSchedules</Typography>
			                </AccordionSummary>
			                <AccordionDetails>
			                    <div style={{display: "flex", flexDirection: "column"}}>
			                        <Typography>
			                            Resource description goes here, manage RoomSchedules below:
			                        </Typography>
			                        <div style={{paddingTop: "20px", display: "flex"}}>
			                            <Button onClick={() => history.push("/management/RoomSchedule_create")} variant="outlined" color="primary">Create RoomSchedule</Button>
                                        <div style={{paddingRight: "10px"}}></div>
                                        <Button onClick={() => history.push("/management/RoomSchedules_overview")} variant="outlined" color="primary">RoomSchedules Overview</Button>
			                        </div>
			                    </div>
			                </AccordionDetails>
			            </Accordion>	
        </div>
    }

    return render();
}

export default ResourceOverviewPage;
