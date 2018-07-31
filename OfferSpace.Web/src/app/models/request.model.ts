import { Catalog } from "./catalog.model";
import { DatePipe } from "@angular/common";
import { Location } from "./location.model";
import { RequestStatus } from "../enums/requestStatus.enum";


export class Request {
  public Id: number;
  public Title: string;
  public Description: string;
  public MinPrice: number;
  public MaxPrice: number;
  public Catalog: Catalog;
  public Location: Location;
  public ScheduleFrom: DatePipe;
  public ScheduleTo: DatePipe;
  public Status: RequestStatus;
}
