import React from 'react'
import AddTypeOfWork from './AddTypeOfWork'
import './styles/TypeOfWork.css'
import TypeOfWorkByCompany from './TypeOfWorkByCompany'
import TypeOfWorkByStaff from './TypeOfWorkByStaff'

function TypeOfWork() {
    return (
        <div className="typeOfWorkContainerDiv">
            <div className="typeOfWorkUpperDiv">
                <AddTypeOfWork/>
            </div>
            <hr/>
            <div className="typeOfWorkLowerDiv">
                <div className="typeOfWorkLeft">
                    <TypeOfWorkByCompany/>
                </div>
                <div className="typeOfWorkRight">
                    <TypeOfWorkByStaff/>
                </div>
            </div>
        </div>
    )
}

export default TypeOfWork
