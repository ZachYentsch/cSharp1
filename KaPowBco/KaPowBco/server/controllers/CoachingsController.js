import { Auth0Provider } from "@bcwdev/auth0provider";
import BaseController from "../utils/BaseController"
import { coachingsService } from "../services/CoachingsService";

export class CoachingsController extends BaseController {
    constructor() {
        super("api/account/coachings")
        this.router
            .use(Auth0Provider.getAuthorizedUserInfo)
            .get('', this.getAccounts)
            .get('/:id', this.getById)
            .post('', this.create)
            .put('/:id', this.edit)
            .delete('/:id', this.remove)
    }

    async getAccounts(req, res, next) {
        try {
            const coachings = await coachingsService.getByAccount(req.userInfo.id)
            return res.send(coachings)
        } catch (error) {
            next(error)
        }
    }

    async getById(req, res, next) {
        try {
            const coaching = await coachingsService.getById(req.params.id, req.userInfo.id)
            return res.send(coaching)
        } catch (error) {
            next(error)
        }
    }

    async create(req, res, next) {
        try {
            req.body.learnerId = req.userInfo.id
            const coaching = await coachingsService.create(req.body)
            return res.send(coaching)
        } catch (error) {
            next(error)
        }
    }

    async edit(req, res, next) {
        try {
            req.body.id = req.params.id
            const editedCoaching = await coachingsService.editCoaching(req.body.id, req.userInfo.id)
            return res.send(editedCoaching)
        } catch (error) {
            next(error)
        }
    }

    async remove(req, res, next) {
        try {
            await coachingsService.remove(req.params.id, req.userInfo.id)
        } catch (error) {
            next(error)
        }
    }
}