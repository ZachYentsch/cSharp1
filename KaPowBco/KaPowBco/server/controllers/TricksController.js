import { Auth0Provider } from "@bcwdev/auth0provider";
import BaseController from "../utils/BaseController"
import { tricksService } from "../services/TricksService";

export class TricksController extends BaseController {
    constructor() {
        super("api/tricks")
        this.router
            .get('', this.getAll)
            .get('/:id', this.getById)
            .use(Auth0Provider.getAuthorizedUserInfo)
            .post('', this.create)
            .put('/:id', this.edit)
            .delete('/:id', this.remove)
    }

    async getAll(req, res, next) {
        try {
            const tricks = await tricksService.getAll()
            return res.send(tricks)
        } catch (error) {
            next(error)
        }
    }

    async getById(req, res, next) {
        try {
            const trickId = await tricksService.getById(req.params.id)
            return res.send(trickId)
        } catch (error) {
            next(error)
        }
    }

    async create(req, res, next) {
        try {
            req.body.accountId = req.userInfo.id
            const createdTrick = await tricksService.create(req.body)
            return res.send(createdTrick)
        } catch (error) {
            next(error)
        }
    }

    async edit(req, res, next) {
        try {
            req.body.id = req.params.id
            const editedTrick = await tricksService.edit(req.params.id, req.userInfo.id)
            return res.send(editedTrick)
        } catch (error) {
            next(error)
        }
    }

    async remove(req, res, next) {
        try {
            const updated = await tricksService.remove(req.params.id, req.userInfo.id)
            return res.send(updated)
        } catch (error) {
            next(error)
        }
    }
}