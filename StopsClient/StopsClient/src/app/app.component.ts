import { Component } from '@angular/core';
import { StopsServiceService} from './stops-service.service';
import { Stops } from './stops';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'StopsClient';
  stops:Stops[];

constructor(private stopService: StopsServiceService)
{

}
apiTimer : any
counter = 10;
stop:number; 
getData(stop)
{
  this.stop = stop; 
  this.stopService.getAllStops( this.stop).subscribe(
    (response:Stops[]) => {
      this.stops =response; 
    }
  );



  this.apiTimer= setInterval(() => {
    this.stopService.getAllStops( this.stop).subscribe(
      (response:Stops[]) => {
        this.stops =response; 
      }
    );
  }, (this.counter*6000));
}
ngOnInit()
{
  

 
}

}
