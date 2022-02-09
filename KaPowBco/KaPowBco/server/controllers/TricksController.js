import { Auth0Provider } from "@bcwdev/auth0provider";
import BaseController from "../utils/BaseController"
import { tricksService } from "../services/TricksService";

export class TricksController extends BaseController {
    constructor() {
        super("api/tricks")
        this.router
            .get('', this.getAll)
    }

    async getAll(req, res, next) {
        try {
            const tricks = await tricksService.getAll()
            return res.send(tricks)
        } catch (error) {
            next(error)
        }
    }
}