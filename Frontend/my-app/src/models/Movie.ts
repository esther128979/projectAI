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
    
    Id : number;
    Name?: string;
    Description? : string; 
    CategoryName? : string;
    AgeGroupName? : string; 
    HasWoman? : boolean;
    LengthMinutes? : number; 
    TotalViews? : number;
    TotalViewers? : number;
    ProductionDate? : Date; 
    PriceBase? :  number;
    PricePerExtraViewer? : number;
    PricePerExtraView? :number; 
    FinalPrice? : number;
    MovieLink? : string; 
    Image? :string;
  }
  export interface MovieToAdd {
   
    Name? : string;
    Description? : string; 
    eCategoryGroup? : CategoryGroup ;
    eAgeGroup? : AgeGroup ;
    HasWoman ? : boolean;
    LengthMinutes? : number; 
    ProductionDate? : Date;  
    PriceBase? :number;
    PricePerExtraViewer? : number;
    PricePerExtraView? : number;
    MovieLink? : string;
    Image? :string;
  

  }