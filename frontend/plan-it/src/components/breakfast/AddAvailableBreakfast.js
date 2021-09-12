import React from 'react'
import AddAvailableBreakfastForInterval from './AddAvailableBreakfastForInterval.js'
import AddOneAvailableBreakfast from './AddOneAvailableBreakfast.js'
import './Breakfast.css'

function AddAvailableBreakfast() {
    return (
        <div>
            <div className="divForCenterContent">
                <label>You have privileges to add breakfast options for your company!</label>
            </div>
            <div className="addBreakfastsDiv">

                <div className="addOneAvailableBreakfastDiv" style={{width:"33%"}}>
                    <AddOneAvailableBreakfast/>
                </div>

                <div className="addAvailableBreakfastForIntervalDiv" style={{width:"33%"}}>
                    <AddAvailableBreakfastForInterval/>
                </div>      
            </div>
        </div>
    )
}

export default AddAvailableBreakfast
