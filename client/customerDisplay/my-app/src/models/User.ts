export enum Gender
{
    male,
    female,
}
export interface User {
    Name: string
    Phone: string
    Email: string
    Id: number
    Address: string
    Gender:Gender;
}
