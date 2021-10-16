import jwt_decode from 'jwt-decode'
import * as generalConstants from '../constants/generalConstants';

export function LocalDateToText(localDate){
    return localDate.day + "-" + localDate.month + "-" + localDate.year
}

export function LocalDateToDateString(localDate) {
    return new Date(localDate.year, localDate.month, localDate.day).toDateString();
}

export function TextToLocalDate(text)
{
    const arr = text.split("-");
    return {
        day:arr[0],
        month:arr[1],
        year:arr[2]
    };
}

export function DateTimeToDateText(dateTime){
    if(dateTime.includes('T'))
    {
        return dateTime.split('T')[0];
    }
    return dateTime;
}

export function CheckIfLoggerUserCanCreate() {
    const token = localStorage.getItem("loginToken");
    const decodedToken = jwt_decode(token);

    console.log(decodedToken);

    return decodedToken.Staff === generalConstants.STAFF_CAN_CREATE;
}

export const makeTextFromListOfBreakfasts = (list) =>{
    console.log(list);
    let text ='';
    list.forEach(element => {
        console.log(element);
        text = text.concat(element);
        text = text.concat(", "); 
    });
    console.log(text);
    return text.substr(0, text.length-2);
};

export function RemoveTAndTimeZoneFromDateTime(dateTime) {
    dateTime = dateTime.replace('T', ' ');
    dateTime = dateTime.split('+')[0];
    return dateTime.split('.')[0];
}

export function CheckIfIAmLoggedIn() {
    const username = localStorage.getItem("username");
    const loginToken = localStorage.getItem("loginToken");
    const companyName = localStorage.getItem("companyName");

    if(username === null || username === undefined || 
        loginToken === null || loginToken === undefined || 
        companyName === null || companyName === undefined)
    {
        return false;
    }
    return true;
}

export function LogOut() {
    localStorage.removeItem("loginToken");
    localStorage.removeItem("username");
    localStorage.removeItem("companyName");
}