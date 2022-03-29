import { post } from 'jquery';
import React, { Component } from 'react';

export class Marketing extends Component {
    static displayName = Counter.name;

    constructor(props) {
        super(props);
        this.state = {
            registo: {}
        };
        this.submitData = this.submitData.bind(this);
    }

    submitData() {
        //should set object data here + loading?
        this.state = { registo: {}, loading: true };

        //submits
       const response = insertRecordData();

         //should verify response and show error or render success message
    }


    insertRecordData() {
        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(registo)
        };

        return await fetch('marketing', requestOptions);

    }


    //defines input form

    static renderForm() {
        return (
            <div>
                <div>
                    <input type="text" id="registoNome" name="registoNome" />
                    <label for="registoNome">Nome</label>
                </div>

                <div>
                    <input type="text" id="registoEmail" name="registoEmail" />
                    <label for="registoEmail">Email</label>
                </div>

                <div>
                    <input type="text" id="registoNumTelefone" name="registoNumTelefone" />
                    <label for="registoNumTelefone">Número Telefone</label>
                </div>

                <div>
                    <input type="checkbox" id="registoTelefone" name="registoTelefone" />
                        <label for="registoTelefone">Telefone</label>
                </div>

                <div>
                    <input type="checkbox" id="registoInternet" name="registoInternet" />
                    <label for="registoInternet">Internet</label>
                </div>

                <div>
                    <input type="checkbox" id="registoTelemovel" name="registoTelemovel" />
                    <label for="registoTelemovel">Telemovel</label>
                </div>


            </div>
        );
    }


    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Marketing.renderForm;

        return (
            <div>
                <h1 id="tabelLabel" >Registo/h1>
                <p>Registe-se para que o possamos cotactar com novas ofertas!</p>
                {contents}
            </div>
        );
    }
}
