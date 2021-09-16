import React, {useState} from 'react'
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogContent from '@material-ui/core/DialogContent';
import DialogActions from '@material-ui/core/DialogActions';
import Spinner from '../Spinner';
import * as urlConstants from '../../constants/urlConstants';

function AddOneAvailableBreakfast() {
    const [selectedDate, setSelectedDate] = useState(new Date());
    const [breakfastItem, setBreakfastItem] = useState(null);
    const [breakfastList, setBreakfastList] = useState([]);
    const [isDialogOpen, setIsDialogOpen] = useState(false);
    const [showSpinner, setShowSpinner] = useState(false);

    const handleAddToList = () => {
        setBreakfastList([...breakfastList, breakfastItem]);
        setBreakfastItem('');
    };

    const handleClearList = () => {
        setBreakfastList([]);
    };

    async function handleAddBreakfast() {
        //setIsDialogOpen(true);
        const url = urlConstants.BASE_URL + urlConstants.ADD_AVAILABLE_BREAKFAST_FOR_A_DATE;
        let partForToken = '';
        const token = localStorage.getItem("loginToken");
        if(token!=null && token!=undefined)
        {
            partForToken = "Bearer "+ token;
        }

        const companyName = localStorage.getItem("companyName");

        if(companyName != null && companyName != undefined)
        {
            const request = {
                companyName: companyName,
                date:selectedDate,
                breakfastItems: breakfastList
            }
            try
            {
                const response = await fetch(url, {
                    method: "POST",
                    headers: { "Content-Type": "application/json",
                    "Authorization":partForToken
                },
                    body: JSON.stringify(request)
                });

                if (response.ok) {
                    window.location.replace("/breakfast");
                }
                else if(response.status === 401) {
                    localStorage.removeItem("loginToken");
                    localStorage.removeItem("username");
                    localStorage.removeItem("companyName");

                    window.location.replace("/");
                }
                else
                {
                }
            }catch(ex) {
                console.log(ex);
            };
        }

        setShowSpinner(false);

        setIsDialogOpen(false);
    };

    const handleCloseDialog = () => {
        setIsDialogOpen(false);
    };

    return (
        <div className="form-group">
            {showSpinner && <Spinner/>}
            <h3>FOR ONE DAY</h3>
            <label>Choose a date:</label>
            <DatePicker className="form-control" 
                selected={selectedDate}
                onChange={date => setSelectedDate(date)}
                dateFormat='dd/MM/yyyy'
                filterDate={date => date.getDay() !== 6 && date.getDay() !== 0}
            />
            <div>
                <br/>
            </div>
            <div className="divForCenterContent">
                <input className="form-control" type="text" placeholder="Enter breakfast item" value={breakfastItem} onChange={(ev) => setBreakfastItem(ev.target.value)}/>
            </div>
            <div>
                <br/>
            </div>
            <div className="divForCenterContent">
                <button className="btn btn-primary" onClick={handleAddToList}>Add item to breakfast list</button>
            </div>
            <div>
                <br/>
            </div>
            <div className="divForCenterContent">
                <textarea className="form-control" rows="5" readOnly value={breakfastList}></textarea>
                <button className="btn btn-secondary" onClick={handleClearList}>Clear list</button>
            </div>
            <div>
                <br/>
                <br/>
            </div>
            <div className="divForCenterContent">
                <button className="btn btn-primary" onClick={() => setIsDialogOpen(true)}>Add breakfast</button>
            </div>
            <Dialog open={isDialogOpen} onClose={handleCloseDialog} aria-labelledby="form-dialog-title">
                <DialogContent>
                    <p>Are you sure that you want to add:
                    <ul>
                        {breakfastList.map(b => {
                            return(
                                <li key={b}>{b}</li>
                            )
                        })}
                    </ul>
                    </p>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleCloseDialog} className="btn btn-secondary">
                        Close
                    </Button>
                    <Button onClick={handleAddBreakfast} className="btn btn-primary">
                        Add
                    </Button>
                </DialogActions>
            </Dialog>
        </div>
    )
}

export default AddOneAvailableBreakfast
