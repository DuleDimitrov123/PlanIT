export function LocalDateToText(localDate){
    return localDate.day + "-" + localDate.month + "-" + localDate.year
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