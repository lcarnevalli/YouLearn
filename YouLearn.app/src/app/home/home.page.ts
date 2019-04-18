import { Component } from "@angular/core";
import { LoadingController } from "@ionic/angular";

@Component({
  selector: "app-home",
  templateUrl: "home.page.html",
  styleUrls: ["home.page.scss"]
})
export class HomePage {
  constructor(public loadingController: LoadingController) {}

  buscarVideo(tag: string) {
    console.log(tag);

    if (tag == null || tag.trim() == "") {
      return;
    }
    this.loadVideo(tag);
  }
  async loadVideo(tag: string) {
    const loading = await this.loadingController.create({
      message: tag,
      duration: 2000
    });
    await loading.present();

    const { role, data } = await loading.onDidDismiss();

    console.log("Loading dismissed!");
  }
}
