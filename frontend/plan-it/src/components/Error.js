import React from 'react';
import { Link } from 'react-router-dom';

const Error = ({customMessage=null}) => {
  return (
    <div>
        <h1>Error Page</h1>
        <br/>
        <div>
            {customMessage && <label style={{color:"red"}}>{customMessage}</label>}
        </div>
        <br/>
        <Link to="/" className="btn btn-primary">Back Home</Link>
    </div>
  );
};

export default Error;
