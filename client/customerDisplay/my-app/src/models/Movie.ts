export enum AgeGroup
{
    Babies,
    Children,
    Teens,
    Adult,
    GoldenAge
}
export enum Status
{
    Oreder,
    History
}
export enum Gender
{
    male,
    female,
}
export enum CategoryGroup
{
    Children,
    Recipes,
    Nature,
    Plot
}

export interface Movie {
    Id:number;
    CategoryGroup?:CategoryGroup;
    AgeGroup?:AgeGroup;
    ThereIsWoman?:boolean;
    Length?:number;
    AmountOfUses?:number;
    FilmProductionDate?:Date;
    MovieName:string;
    MovieDescription?:string;
    MovieUrl?:string;
    MoviePrice?:number;
    MovieImage?:string;
  }