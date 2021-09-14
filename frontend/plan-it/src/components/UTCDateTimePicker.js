import React from 'react';
import DateTimePicker from 'react-datetime-picker';


function convertUTCToLocalDate(date) {
  if (!date) {
    return date
  }
  date = new Date(date)
  date = new Date(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(), date.getUTCHours(), date.getUTCMinutes(), date.getUTCSeconds())
  return date
}

function convertLocalToUTCDate(date) {
  if (!date) {
    return date
  }
  date = new Date(date)
  date = new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds()))
  return date
}

export default function UTCDateTimePicker({ startDate, endDate, selected, onChange, ...props }) {
  return (
    <DateTimePicker
      startDate={convertUTCToLocalDate(startDate)}
      endDate={convertUTCToLocalDate(endDate)}
      selected={convertUTCToLocalDate(selected)}
      onChange={date => onChange(convertLocalToUTCDate(date))}
      {...props}
    />
  )
}