import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>EmployeeID</th>
            <th>Employee Name</th>
            <th>so gio</th>
                    <th>so tien</th>
                    <th>salary employee</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
              <tr key={forecast.employeeId}>
                  <td>{forecast.employeeId}</td>
              <td>{forecast.employeeName}</td>
              <td>{forecast.sogio}</td>
              <td>{forecast.sotien}</td>
              <td>{forecast.salaryemployee}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Employee salary</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('weatherforecast/getAll');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
