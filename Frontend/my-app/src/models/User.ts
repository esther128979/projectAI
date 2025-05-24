export enum Gender
{
    male,
    female,
}
export enum AgeGroup
{
   
        Babies,
        Children,
        Teens,
        Adult,
        GoldenAge
    
}
export interface User {
    Name: string
    Phone: string
    Email: string
    Id: number
    Address: string
   AgeGroup:AgeGroup
    Gender:Gender
}
