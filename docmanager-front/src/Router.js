import React from 'react';
import ManagerContainer from './container/managerContainer.js';

class RouterComponent extends React.Component {
    render() {
      const { history } = this.props;
      return (
        // <ConnectedRouter history={history}>
          <ManagerContainer/> 
        // </ConnectedRouter>
      );
    }
  }
  
  export default RouterComponent;