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

export interface MovieObject {
    Id:number;
    CategoryGroup?:CategoryGroup;
    AgeGroup?:AgeGroup;
    ThereIsWoman?:boolean;
    Duration?:number;
    AmountOfViews?:number;
    FilmProductionDate?:Date;
    Name:string;
    Description?:string;
    Url?:string;
    Price:number;
    Image?:string;
  
  }
// export interface MovieObject {
//     id?: number; 
//   name?: string;
//   description?: string;
//   codeCategory?: CategoryGroup;    
//   ageGroup?: AgeGroup;              
//   hasWoman?: boolean;
//   lengthMinutes?: number;
//   productionDate?: Date;
//   priceBase?: number;             
//   pricePerExtraViewer?: number;
//   pricePerExtraView?: number;
//   movieLink?: string;
//   imageUrl?: string;
// }