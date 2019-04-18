import { LoadingController } from "@ionic/angular";
import { Injectable } from "@angular/core";

@Injectable()
export class utilService {
  constructor(public loadCtrl: LoadingController) {}

  public showLoading(message: string = "Processando ...."): any {
    let Loading = this.loadCtrl.create({ message: message });
    return Loading;
  }
}
