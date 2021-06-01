import React, { Component } from 'react';
import { Redirect, Route, Switch } from 'react-router';
import { BrowserRouter as Router} from 'react-router-dom';
import LoginPage from '../pages/LoginPage';
import BookingPage from '../pages/BookingPage';
import ResourceOverviewPage from '../pages/management/ResourceOverviewPage';
import UserPage from '../pages/UserPage';
import BookingOverviewPage from '../pages/BookingOverviewPage';
import SpasOverviewPage from '../pages/management/Spa/SpasOverviewPage';
import UpdateSpaPage from '../pages/management/Spa/UpdateSpaPage';
import CreateSpaPage from '../pages/management/Spa/CreateSpaPage';
import RoomsOverviewPage from '../pages/management/Room/RoomsOverviewPage';
import UpdateRoomPage from '../pages/management/Room/UpdateRoomPage';
import CreateRoomPage from '../pages/management/Room/CreateRoomPage';
import SuitesOverviewPage from '../pages/management/Suite/SuitesOverviewPage';
import UpdateSuitePage from '../pages/management/Suite/UpdateSuitePage';
import CreateSuitePage from '../pages/management/Suite/CreateSuitePage';
import NCustomersOverviewPage from '../pages/management/NCustomer/NCustomersOverviewPage';
import UpdateNCustomerPage from '../pages/management/NCustomer/UpdateNCustomerPage';
import CreateNCustomerPage from '../pages/management/NCustomer/CreateNCustomerPage';
import VipCustomersOverviewPage from '../pages/management/VipCustomer/VipCustomersOverviewPage';
import UpdateVipCustomerPage from '../pages/management/VipCustomer/UpdateVipCustomerPage';
import CreateVipCustomerPage from '../pages/management/VipCustomer/CreateVipCustomerPage';
import RoomSchedulesOverviewPage from '../pages/management/RoomSchedule/RoomSchedulesOverviewPage';
import UpdateRoomSchedulePage from '../pages/management/RoomSchedule/UpdateRoomSchedulePage';
import CreateRoomSchedulePage from '../pages/management/RoomSchedule/CreateRoomSchedulePage';

const App = () => {

  const render = () => {
    return <Router>
      <Switch>
      	<Route exact path="/management/Spas_overview" component={SpasOverviewPage}/>
      	<Route exact path="/management/Spa_update/:id" component={UpdateSpaPage}/>
      	<Route exact path="/management/Spa_create" component={CreateSpaPage}/>
      	<Route exact path="/management/Rooms_overview" component={RoomsOverviewPage}/>
      	<Route exact path="/management/Room_update/:id" component={UpdateRoomPage}/>
      	<Route exact path="/management/Room_create" component={CreateRoomPage}/>
      	<Route exact path="/management/Suites_overview" component={SuitesOverviewPage}/>
      	<Route exact path="/management/Suite_update/:id" component={UpdateSuitePage}/>
      	<Route exact path="/management/Suite_create" component={CreateSuitePage}/>
      	<Route exact path="/management/NCustomers_overview" component={NCustomersOverviewPage}/>
      	<Route exact path="/management/NCustomer_update/:id" component={UpdateNCustomerPage}/>
      	<Route exact path="/management/NCustomer_create" component={CreateNCustomerPage}/>
      	<Route exact path="/management/VipCustomers_overview" component={VipCustomersOverviewPage}/>
      	<Route exact path="/management/VipCustomer_update/:id" component={UpdateVipCustomerPage}/>
      	<Route exact path="/management/VipCustomer_create" component={CreateVipCustomerPage}/>
      	<Route exact path="/management/RoomSchedules_overview" component={RoomSchedulesOverviewPage}/>
      	<Route exact path="/management/RoomSchedule_update/:id" component={UpdateRoomSchedulePage}/>
      	<Route exact path="/management/RoomSchedule_create" component={CreateRoomSchedulePage}/>
      	<Route exact path="/management/overview" component={ResourceOverviewPage}/>
        <Route exact path="/booking/:id/:type" component={BookingPage}/>
        <Route exact path="/userpage/:id/:type" component={UserPage}/>
        		<Route exact path="/bookingoverview/:id/:type" component={BookingOverviewPage}/>
        		<Route exact path="/login" component={LoginPage}/>
        		<Redirect to="/login"/>
      </Switch>
    </Router>
  }

  return render();

}

export default App;
